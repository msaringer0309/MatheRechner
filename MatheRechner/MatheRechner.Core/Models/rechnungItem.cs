using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mathekönig.Models
{
    [Table("rechnung")]
    public class RechnungItem : IRechnungItem
    {

        [PrimaryKey, Column("Rechnungsnummer")]

        public string Rechnungsnummer { get; set; } = Guid.NewGuid().ToString();

        
        
        
        
        [MaxLength(250), NotNull, Column("Name")]

        public string Name { get; set; }


        
        
        
        [MaxLength(250), NotNull, Column("Richtige")]
        public int Richtige { get; set; }

        
        
        
        [MaxLength(250), NotNull, Column("Falsche")]

        public int Falsche { get; set; }


        
        
        
        [NotNull, Column("gendate")]

        public DateTime GeneratedDateTime { get; set; }

    }
}
