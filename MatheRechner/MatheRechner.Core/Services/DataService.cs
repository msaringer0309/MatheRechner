using Mathekönig.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mathekönig.Services
{
    public class DataService : IDataService
    {
        protected List<IrechnungItem> _rechnungen = new List<IrechnungItem>();

        public bool Add(IrechnungItem rechnung)
        {
            throw new NotImplementedException();
        }

        public List<IrechnungItem> All()
        {
            throw new NotImplementedException();
        }

        public bool Delete(IrechnungItem rechnung)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
