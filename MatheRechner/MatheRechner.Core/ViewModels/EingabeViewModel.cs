
using Mathekönig.Models;
using Mathekönig.Services;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MatheKönig.Core.ViewModels
{
    public class EingabeViewModel : MvxViewModel
    {
        private IDataService _dataService;

        private MvxObservableCollection<IRechnungItem> _rechungen;

        
    }
}
    

