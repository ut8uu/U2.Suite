using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using JorgeSerrano.Json;

namespace U2.QslManager
{
    public static class Utilities
    {
        private static QslCardElement GetTextElement(string title, string name,
            int startX, int startY, int fontSize)
        {
            return new QslCardElement
            {
                ElementType = QslCardElementType.Text,
                ElementTitle = title,
                ElementName = name,
                TransformationAngle = 0,
                StartPositionMm = new Position(startX, startY),
                EndPositionMm = new Position(0, 0),
                Font = new QslCardElementFont
                {
                    Bold = true,
                    Italic = false,
                    Color = "White",
                    Name = "Arial",
                    Size = fontSize
                }
            };
        }

        private static QslCardElement GetImageElement(
            string name,
            int startX, int startY,
            int endX, int endY,
            int order)
        {
            return new QslCardElement
            {
                ElementType = QslCardElementType.Text,
                ElementName = name,
                TransformationAngle = 0,
                StartPositionMm = new Position(startX, startY),
                EndPositionMm = new Position(endX, endY),
                Order = order,
            };
        }

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                IgnoreNullValues = true,
                PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };
        }

        /// <summary>
        /// Generates a demo template of the design object.
        /// </summary>
        /// <returns></returns>
        public static string GenerateDesignTemplate()
        {
            var template = new QslCardDesign
            {
                AuthoredBy = "Sergey Usmanov, UT8UU",
                DesignName = "Demo Design",
                CardSizeMM = new Dimensions(150, 100),
                DensityDpi = 96,
                BackgroundColor = "DarkGreen",
                BackgroundImage = string.Empty,
                Elements = new[]
                {
                    GetTextElement(string.Empty, DesignElements.Callsign, 50, 5, 72),
                    GetTextElement("op.", DesignElements.OperatorName, 80, 35, 16),
                    GetTextElement("CQ zone:", DesignElements.CqZone, 30, 5, 12),
                    GetTextElement("ITU zone:", DesignElements.ItuZone, 50, 5, 12),
                    GetTextElement("Grid:", DesignElements.Grid, 70, 5, 12),
                    GetTextElement("QTH:", DesignElements.Qth, 100, 5, 12),
                    GetTextElement(string.Empty, DesignElements.Text1, 20, 80, 12),
                    GetTextElement(string.Empty, DesignElements.Text2, 20, 90, 12),
                    GetImageElement(DesignElements.BackgroundImage, 0, 0, 150, 100, order: 0),
                    GetImageElement(DesignElements.Image1, 100, 20, 140, 80, order: 10),
                },
                GridInfo = new QslCardGridInfo
                {
                    StartPositionMm = new Position
                    {
                        X = 20,
                        Y = 70
                    },
                    BackgroundColor = "White",
                    ForegroundColor = "DarkNavy",
                    RowCount = 1,
                    HeaderHeightMm = 10,
                    RowHeightMm = 10,
                    Columns = new List<QslCardGridColumn>
                    {
                        new QslCardGridColumn
                        {
                            Title = "To radio",
                            WidthMm = 30,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Date",
                            WidthMm = 20,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Time",
                            WidthMm = 20,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Freq",
                            WidthMm = 20,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Report",
                            WidthMm = 15,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Mode",
                            WidthMm = 15,
                        },
                    }
                }
            };

            return JsonSerializer.Serialize(template, GetJsonSerializerOptions());
        }

        public static bool TryParseDesignTemplateFromString(string json, out QslCardDesign? qslCardDesign)
        {
            qslCardDesign = null;
            try
            {
                qslCardDesign = JsonSerializer.Deserialize<QslCardDesign>(json, GetJsonSerializerOptions());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool TryParseDesignTemplateFromFile(string pathToTemplate, out QslCardDesign? qslCardDesign)
        {
            qslCardDesign = null;
            try
            {
                var content = File.ReadAllText(pathToTemplate);
                return TryParseDesignTemplateFromString(content, out qslCardDesign);
            }
            catch
            {
                return false;
            }
        }

        public static List<QslCardDesign> GetDesigns()
        {
            var designs = new List<QslCardDesign>();

            var assemblyDirectory = Path.GetDirectoryName(typeof(Utilities).Assembly.Location);
            Debug.Assert(!string.IsNullOrEmpty(assemblyDirectory));
            var designsDirectory = Path.Combine(assemblyDirectory, "Designs");
            var files = Directory.GetFiles(designsDirectory, "*.json");
            foreach (var file in files)
            {
                if (TryParseDesignTemplateFromFile(file, out var cardDesign))
                {
                    Debug.Assert(cardDesign != null);
                    cardDesign.DesignLocation = file;
                    designs.Add(cardDesign);
                }
            }

            return designs;
        }

        public static bool TryParseQslCardDataFromString(string json, out QslCardFieldsModel fields)
        {
            fields = null;
            try
            {
                fields = JsonSerializer.Deserialize<QslCardFieldsModel>(json, GetJsonSerializerOptions());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool TryParseQslCardDataFromFile(string pathToFile, out QslCardFieldsModel fields)
        {
            fields = null;
            try
            {
                var content = File.ReadAllText(pathToFile);
                return TryParseQslCardDataFromString(content, out fields);
            }
            catch
            {
                return false;
            }
        }

        public static string SerializeQslCardDataToString(QslCardFieldsModel fields)
        {
            return JsonSerializer.Serialize(fields, GetJsonSerializerOptions());
        }

        public static void SerializeQslCardDataToFile(string pathToFile, QslCardFieldsModel fields)
        {
            var content = JsonSerializer.Serialize(fields, GetJsonSerializerOptions());
            var directory = Path.GetDirectoryName(pathToFile);
            Directory.CreateDirectory(directory);
            File.WriteAllText(pathToFile, content);
        }

        public static void SerializeQslCardDesignToFile(string pathToFile, QslCardDesign design)
        {
            var content = JsonSerializer.Serialize(design, GetJsonSerializerOptions());
            var directory = Path.GetDirectoryName(pathToFile);
            Directory.CreateDirectory(directory);
            File.WriteAllText(pathToFile, content);
        }
    }
}
