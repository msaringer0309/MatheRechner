using Mathekönig.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mathekönig.Services
{
    public class DataService : IDataService
    {
        protected List<IrechnungItem> _rechnungen = new List<IrechnungItem>();

       
        public DataService()
        {
            Debug.WriteLine("DataService wurde erstellt");
        }
        
        public bool Add(IrechnungItem rechnung)
        {
            this._rechnungen.Add(rechnung);
            return true;
        }

        public List<IrechnungItem> All()
        {
            return this._rechnungen;
        }

        public bool Delete(IrechnungItem rechnung)
        {
            return this._rechnungen.Remove(rechnung);
        }

        public bool Save()
        {
            return true;
        }
    }
}
