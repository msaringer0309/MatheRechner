using Mathekönig.Models;
using Mathekönig.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MatheKönig.Core.Services
{
    public class SqlData : IDataService
    {
        private string Filename { get; set; } = "rechnungen.db";

        private string Dir { get; set; } = Directory.GetCurrentDirectory();

        private string CalcFilePath { get; set; }
        
        private SQLiteConnection Conn { get; set; }

        public SqlData()
        {
            this.CalcFilePath = Path.Combine(this.Dir, this.Filename);

            var options = new SQLiteConnectionString(this.CalcFilePath, true, key: "Fortnite");
            this.Conn = new SQLiteConnection(options);

            this.Conn.CreateTable<RechnungItem>();
        }
        
        public List<IRechnungItem> All()
        {
            //alle Rechnungen aufzählen
            var rechnungen = from r in this.Conn.Table<RechnungItem>()
                             select new RechnungItem()
                             {
                                 Rechnungsnummer = r.Rechnungsnummer,
                                 Name = r.Name,
                                 Richtige = r.Richtige,
                                 Falsche = r.Falsche,
                                 GeneratedDateTime = r.GeneratedDateTime
                             };
            
           return rechnungen.ToList<IRechnungItem>();

        }

        public bool Add(IRechnungItem rechnung)
        {
            var count = this.Conn.Insert(rechnung);
                return count > 0;
        }

        

        

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
