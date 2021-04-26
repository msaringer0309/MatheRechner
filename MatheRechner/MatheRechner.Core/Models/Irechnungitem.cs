using System;
using System.Collections.Generic;
using System.Text;

namespace Mathekönig.Models
{
    public interface IRechnungItem
    {
        string Rechnungsnummer { get; set; }

        public string Name { get; set; }
        public int Richtige { get; set; }
        public int Falsche { get; set; }

        public DateTime GeneratedDateTime { get; set; }


    }
}
