using Avalonia.Controls;
using JorgeSerrano.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;

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
                StartPositionMM = new Position(startX, startY),
                EndPositionMM = new Position(0, 0),
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
                StartPositionMM = new Position(startX, startY),
                EndPositionMM = new Position(endX, endY),
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
                DesignName = "Demo Design",
                CardSizeMM = new Dimensions(150, 100),
                DensityDpi = 96,
                Elements = new[]
                {
                    GetTextElement(string.Empty, DesignElements.Callsign, 20, 10, 72),
                    GetTextElement("op.", DesignElements.OperatorName, 80, 40, 16),
                    GetTextElement("CQ zone:", DesignElements.CqZone, 20, 12, 12),
                    GetTextElement("ITU zone:", DesignElements.ItuZone, 40, 12, 12),
                    GetTextElement("Grid:", DesignElements.Grid, 60, 12, 12),
                    GetTextElement("QTH:", DesignElements.Qth, 90, 12, 12),
                    GetTextElement(string.Empty, DesignElements.Text1, 20, 80, 12),
                    GetTextElement(string.Empty, DesignElements.Text2, 20, 90, 12),
                    GetImageElement(DesignElements.BackgroundImage, 0, 0, 150, 100, order: 0),
                    GetImageElement(DesignElements.Image1, 100, 20, 140, 80, order: 10),
                },
                GridInfo = new QslCardGridInfo
                {
                    StartPositionMM = new Position
                    {
                        X = 20,
                        Y = 70
                    },
                    BackgroundColor = "White",
                    LineColor = "DarkNavy",
                    RowCount = 1,
                    HeaderHeightMM = 10,
                    RowHeightMM = 10,
                    Columns = new List<QslCardGridColumn>
                    {
                        new QslCardGridColumn
                        {
                            Title = "To radio",
                            WidthMM = 30,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Date",
                            WidthMM = 20,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Time",
                            WidthMM = 20,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Freq",
                            WidthMM = 20,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Report",
                            WidthMM = 15,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Mode",
                            WidthMM = 15,
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
                    designs.Add(cardDesign);
                }
            }

            return designs;
        }
    }
}
