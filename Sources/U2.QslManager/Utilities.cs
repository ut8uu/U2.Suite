using Avalonia.Controls;
using JorgeSerrano.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.Design.AxImporter;

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
                DensityDpi = 300,
                Elements = new[]
                {
                    GetTextElement(string.Empty, DesignElements.Callsign, 10, 80, 32),
                    GetTextElement("op.", DesignElements.OperatorName, 20, 70, 16),
                    GetTextElement("CQ zone:", DesignElements.CqZone, 20, 65, 12),
                    GetTextElement("ITU zone:", DesignElements.ItuZone, 30, 65, 12),
                    GetTextElement("Grid:", DesignElements.Grid, 60, 65, 12),
                    GetTextElement("QTH:", DesignElements.Qth, 90, 65, 12),
                    GetTextElement(string.Empty, DesignElements.Text1, 20, 15, 12),
                    GetTextElement(string.Empty, DesignElements.Text2, 20, 5, 12),
                    GetImageElement(DesignElements.BackgroundImage, 0, 0, 150, 100, order: 0),
                    GetImageElement(DesignElements.Image1, 100, 20, 140, 80, order: 10),
                },
                GridInfo = new QslCardGridInfo
                {
                    StartPositionMM = new Position
                    {
                        X = 10,
                        Y = 10
                    },
                    BackgroundColor = "#FFFFFF",
                    LineColor = "#000000",
                    RowCount = 1,
                    HeaderHeightMM = 10,
                    RowHeightMM = 10,
                    Columns = new List<QslCardGridColumn>
                    {
                        new QslCardGridColumn
                        {
                            Title = "To radio",
                            WidthMM = 50,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Date",
                            WidthMM = 30,
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
                            WidthMM = 25,
                        },
                        new QslCardGridColumn
                        {
                            Title = "Mode",
                            WidthMM = 25,
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
