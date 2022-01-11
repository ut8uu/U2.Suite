using System;
using System.Collections.Generic;
using System.Text;
using U2.Library.Database.Models;
using U2.Resources.Collections;

namespace U2.Library.Database.Rigs.Wouxun
{
    public abstract class WouxunRadios
    {
        public static List<RigDbo> GetRadios()
        {
            var list = new List<RigDbo>();
            list.Add(new RigDbo
            {
                Id = list.Count + 1,
                Name = "KG UV-6D",
                VendorId = VendorIds.WouxunId,
                WeightGrams = 253,
                Width = 65,
                Height = 119,
                Depth = 40,
                PowerWatts = 5,
                DataDirectory = "Wouxun/KGUV6D",
            });

            return list;
        }
    }
}
