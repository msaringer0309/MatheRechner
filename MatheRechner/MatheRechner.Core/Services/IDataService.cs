using Mathekönig.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mathekönig.Services
{
    public interface IDataService
    {
        List<IRechnungItem> All();

        bool Add(IRechnungItem rechnung);

        bool Delete(IRechnungItem rechnung);

        bool Save();
    }
}
