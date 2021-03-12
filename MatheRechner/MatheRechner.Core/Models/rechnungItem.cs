using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mathekönig.Models
{
    [Table("rechnung")]
    public class rechnungItem
    {
        [PrimaryKey, Column("Rechnungsnummer")]

        public string Rechnungsnummer { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(250), NotNull, Column("Rechnung")]

        public string Rechnung { get; set; }

        [NotNull, Column("gendate")]

        public DateTime GeneratedDateTime { get; set; }

    }
}
