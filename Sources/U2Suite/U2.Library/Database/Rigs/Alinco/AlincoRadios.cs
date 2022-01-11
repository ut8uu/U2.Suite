using System;
using System.Collections.Generic;
using System.Text;
using U2.Library.Database.Models;
using U2.Resources.Collections;

namespace U2.Library.Database.Rigs.Alinco
{
    public abstract class AlincoRadios
    {
        public static List<RigDbo> GetRadios()
        {
            var list = new List<RigDbo>();
            list.Add(new RigDbo
            {
                Id = list.Count + 1,
                Name = "DJ-X1",
                VendorId = VendorIds.AlincoId,
                WeightGrams = 150,
                Width = 58,
                Height = 100,
                Depth = 19,
                ManufactureStart = 2004,
                DataDirectory = "Alinco/DJX01",
            });

            return list;
        }
    }
}
