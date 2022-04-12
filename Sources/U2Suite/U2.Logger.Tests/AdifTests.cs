using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Contracts;
using U2.Logger;

namespace U2.Logger.Tests;

[TestClass]
public class AdifTests
{
    private string _pathToFile;
    private string _pathToBakFile;
    private DateTime _expectedDate = DateTime.UtcNow;

    [TestInitialize]
    public void InitTest()
    {
        _pathToFile = Path.GetTempFileName();
        _pathToBakFile = $"{_pathToFile}.bak";
    }

    [TestCleanup]
    public void Cleanup()
    {
        if (File.Exists(_pathToFile))
        {
            File.Delete(_pathToFile);
        }
        if (File.Exists(_pathToBakFile))
        {
            File.Delete(_pathToBakFile);
        }
    }

    [TestMethod]
    public void CanGenerateAdif()
    { 
        var storage = TestData.GetLogRecords();
        var logInfo = PrepareLogInfo();
        var expectedDate = _expectedDate.ToString("yyyyMMdd");
        var expectedTime = _expectedDate.ToString("HHmmss");

        var adif = AdifHelper.GenerateAdif(logInfo, storage);

        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagCall}:5>ON4ON"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagCall}:5>UT2AB"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagCall}:4>N1MM"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagBand}:3>{RadioBandName.B17m}"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagBand}:3>{RadioBandName.B20m}"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagBand}:3>{RadioBandName.B40m}"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagFreq}:5>7.023"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagFreq}:6>14.223"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagFreq}:6>18.160"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagMode}:2>CW"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagMode}:3>SSB"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagMode}:4>RTTY"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagRstRcvd}:3>599"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagRstRcvd}:3>579"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagRstRcvd}:3>559"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagRstSent}:3>589"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagRstSent}:3>569"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagRstSent}:3>549"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagQsoDate}:8>{expectedDate}"));
        Assert.IsTrue(adif.Contains($"<{KnownAdifTags.TagTimeOn}:6>{expectedTime}"));
    }

    private LogInfo PrepareLogInfo()
    {
        return LogInfoTestHelper.GetLogInfo();
    }

    [TestMethod]
    public async Task ParseAdif()
    {
        var testData = TestData.GetLogRecords();
        var expectedRow = testData.First();
        var adif = AdifHelper.GenerateAdif(PrepareLogInfo(), testData);
        var errors = new List<LogEntry>();
        var collection = await AdifHelper.ParseAdifAsync(adif, CancellationToken.None, errors);

        var actualRow = collection.First();
        Assert.AreEqual(expectedRow.Callsign, actualRow.Callsign);
        Assert.AreEqual(expectedRow.Comments, actualRow.Comments);
        Assert.AreEqual(expectedRow.Band, actualRow.Band);
        Assert.AreEqual(expectedRow.Mode, actualRow.Mode);
        Assert.AreEqual(expectedRow.Frequency, actualRow.Frequency);
        Assert.AreEqual(expectedRow.RstReceived, actualRow.RstReceived);
        Assert.AreEqual(expectedRow.RstSent, actualRow.RstSent);
        var timestampFormat = "yyyy MM dd HH mm ss";
        Assert.AreEqual(expectedRow.QsoEndTimestamp.ToString(timestampFormat), actualRow.QsoEndTimestamp.ToString(timestampFormat));
    }

    [TestMethod]
    [DataRow("", false, "")]
    [DataRow("urff-1", true, "URFF-0001")]
    [DataRow("urff-0001", true, "URFF-0001")]
    [DataRow("urff0001", true, "URFF-0001")]
    [DataRow("urff 0001", true, "URFF-0001")]
    [DataRow("fff-0001", true, "FFF-0001")]
    [DataRow("S5ff-0001", true, "S5FF-0001")]
    public void ExtractWwffReferences(string testString, bool shouldHaveReference, string expectedReference)
    {
        var (hasReference, foundReference) = AdifHelper.ExtractWwffReference(testString);
        Assert.AreEqual(shouldHaveReference, hasReference);
        Assert.AreEqual(expectedReference, foundReference);
    }

    [TestMethod]
    [DataRow("", false, "")]
    [DataRow("f/ab-123", true, "F/AB-123")]
    [DataRow("f/ab-12", true, "F/AB-012")]
    [DataRow("fab-12", true, "F/AB-012")]
    [DataRow("URab-12", true, "UR/AB-012")]
    [DataRow("S5/SS-12", true, "S5/SS-012")]
    [DataRow("S5/SS-1234", false, "")]
    [DataRow("URFF-1234", false, "")]
    public void ExtractSotaReferences(string testString, bool shouldHaveReference, string expectedReference)
    {
        var (hasReference, foundReference) = AdifHelper.ExtractSotaReference(testString);
        Assert.AreEqual(shouldHaveReference, hasReference);
        Assert.AreEqual(expectedReference, foundReference);
    }

    [TestMethod]
    [DataRow(160, "MW0MJA/P")]
    [DataRow(10, "OH1MM")]
    [DataRow(20, "DL5EBG")]
    [DataRow(30, "DL7VEA")]
    [DataRow(40, "UA4PKN")]
    [DataRow(50, "DL1EJG")]
    [DataRow(60, "SP2SV")]
    [DataRow(70, "R2VQ")]
    [DataRow(80, "LX1CC")]
    [DataRow(90, "F4CTJ")]
    [DataRow(100, "OF6GAZ")]
    [DataRow(110, "IS0LYN")]
    [DataRow(120, "DL3HXX")]
    [DataRow(130, "OH3BHL")]
    [DataRow(140, "M1TES")]
    [DataRow(150, "I4RHP")]
    [DataRow(155, "S52ON")]
    [DataRow(170, "RK1AQ")]
    [DataRow(180, "DH8WC")]
    [DataRow(190, "UR7ET")]
    public async Task CanParseUrff0206(int rowIndex, string callsign)
    {
        var thisDirectory = Path.GetDirectoryName(this.GetType().Assembly.Location);
        var path = Path.Combine(thisDirectory, "TestData", "URFF0206.adi");
        var errors = new List<LogEntry>();
        var records = await AdifHelper.LoadAdifAsync(path, CancellationToken.None, errors);

        Assert.AreEqual(190, records.Count());

        var record = records.ElementAt(rowIndex - 1);

        Assert.AreEqual(record.Callsign, callsign);
    }

    [TestMethod]
    public async Task CanCancelLoadingFromAdifFile()
    {
        var thisDirectory = Path.GetDirectoryName(this.GetType().Assembly.Location);
        var path = Path.Combine(thisDirectory, "TestData", "URFF0206.adi");

        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();

        var errors = new List<LogEntry>();
        var records = await AdifHelper.LoadAdifAsync(path, cancellationTokenSource.Token, errors);

        Assert.AreEqual(0, records.Count());
        Assert.AreEqual(1, errors.Count());
        var error = errors.Single(e => e.Type == LogEntryType.Error && e.Message == Resources.OperationCancelledMessage);
    }

    [TestMethod]
    public async Task CanFindDuplicates()
    {
        var logRecord = new LogRecordDbo
        {
            Band = RadioBandName.B10m,
            Mode = RadioMode.RTTY,
            Callsign = "UT8UU",
            QsoEndTimestamp = DateTime.UtcNow,
        };

        var mainLog = new List<LogRecordDbo>
        {
            logRecord,
        };
        var hashes = mainLog.Select(l => l.Hash);
        var newLog = new List<LogRecordDbo>
        {
            logRecord,
        };

        Assert.IsTrue(AdifHelper.HasDuplicates(hashes, newLog, out var duplicates));
        Assert.IsTrue(duplicates.Any());
    }
}
