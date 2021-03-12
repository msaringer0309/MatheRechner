﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mathekönig.Models
{
    public interface IRechnungItem
    {
        string Rechnungsnummer { get; set; }

        public string Rechnung { get; set; }

        public DateTime GeneratedDateTime { get; set; }


    }
}
