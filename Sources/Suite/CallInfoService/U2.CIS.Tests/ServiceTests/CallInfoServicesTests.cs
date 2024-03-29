using DeepEqual.Syntax;
using U2.CIS.Core;

namespace U2.CIS.Tests;

public class CallInfoServicesTests : CisTestsBase 
{
	private const string UT8UU = nameof(UT8UU);
	private const string UT2UU = nameof(UT2UU);

	[Fact]
	public async Task CanAddCallInfo()
	{
		CancellationToken cancellationToken = new();
		_callInfos.Clear();
		await SetupCisDbContext();

		var service = new CallInfoService(_dbContext);
		var count = service.GetCallInfoCount();
		Assert.Equal(0, count);

		var id = await service.AddCallAsync("UT8UU", cancellationToken);
		Assert.Equal(1, id);
		count = service.GetCallInfoCount();
		Assert.Equal(1, count);
	}

	[Fact]
	public async Task CanDeleteCallInfo()
	{

		CancellationToken cancellationToken = new();
		_callInfos.Clear();
		_callInfos.Add(GetCallInfo(call: UT8UU));
		await SetupCisDbContext();

		var service = new CallInfoService(_dbContext);
		var count = service.GetCallInfoCount();
		Assert.Equal(1, count);

		var success = await service.DeleteCallAsync(UT8UU, cancellationToken);
		Assert.True(success);

		success = await service.DeleteCallAsync(UT2UU, cancellationToken);
		Assert.False(success);
	}

	[Fact]
	public async Task CanUpdateCallInfo()
	{
		var newCallInfo = GetCallInfo(call: UT8UU);

		CancellationToken cancellationToken = new();
		_callInfos.Clear();
		await SetupCisDbContext();

		var service = new CallInfoService(_dbContext);
		var existingCallInfoId = await service.AddCallAsync(UT8UU, cancellationToken);
		var count = service.GetCallInfoCount();
		Assert.Equal(1, count);

		await service.UpdateCallAsync(existingCallInfoId, newCallInfo, cancellationToken);
		
		var updatedCallInfo = await service.GetCallInfoAsync(UT8UU, cancellationToken);
		updatedCallInfo.WithDeepEqual(newCallInfo).Assert();
	}

	[Fact]
	public async Task MustIgnoreNonExistentEntries()
	{
		var service = new CallInfoService(_dbContext);
		var success = await service.UpdateCallAsync(0, GetCallInfo(), CancellationToken.None);
		Assert.False(success);
	}
}