using Mathekönig.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mathekönig.Services
{
    public interface IDataService
    {
        List<IrechnungItem> All();

        bool Add(IrechnungItem rechnung);

        bool Delete(IrechnungItem rechnung);

        bool Save();
    }
}
