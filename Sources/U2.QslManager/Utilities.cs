using JorgeSerrano.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.Json;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.Design.AxImporter;

namespace U2.QslManager
{
    public static class Utilities
    {
        private static QslCardElement GetTextElement(string name,
            int startX, int startY, int fontSize)
        {
            return new QslCardElement
            {
                ElementType = QslCardElementType.Text,
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
                    GetTextElement(DesignElements.Callsign, 10, 80, 32),
                    GetTextElement(DesignElements.OperatorName, 20, 70, 16),
                    GetTextElement(DesignElements.CqZone, 20, 65, 12),
                    GetTextElement(DesignElements.ItuZone, 30, 65, 12),
                    GetTextElement(DesignElements.Grid, 60, 65, 12),
                    GetTextElement(DesignElements.Qth, 90, 65, 12),
                    GetTextElement(DesignElements.Text1, 20, 15, 12),
                    GetTextElement(DesignElements.Text2, 20, 5, 12),
                    GetImageElement(DesignElements.BackgroundImage, 0, 0, 150, 100, order: 0),
                    GetImageElement(DesignElements.Image1, 100, 20, 140, 80, order: 10),
                }
            };

            return JsonSerializer.Serialize(template, GetJsonSerializerOptions());
        }

        public static bool TryParseDesignTemplate(string json, out QslCardDesign? qslCardDesign)
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
    }
}
