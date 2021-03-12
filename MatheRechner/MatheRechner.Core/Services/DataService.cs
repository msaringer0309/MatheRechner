using Mathekönig.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mathekönig.Services
{
    public class DataService : IDataService
    {
        protected List<IRechnungItem> _rechnungen = new List<IRechnungItem>();

       
        public DataService()
        {
            Debug.WriteLine("DataService wurde erstellt");
        }
        
        public bool Add(IRechnungItem rechnung)
        {
            this._rechnungen.Add(rechnung);
            return true;
        }

        public List<IRechnungItem> All()
        {
            return this._rechnungen;
        }

        public bool Delete(IRechnungItem rechnung)
        {
            return this._rechnungen.Remove(rechnung);
        }

        public bool Save()
        {
            return true;
        }
    }
}
