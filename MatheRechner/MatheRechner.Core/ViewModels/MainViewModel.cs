using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCross.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using MvvmCross.Navigation;
using Mathekönig.Services;

namespace MatheKönig.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        IDataService _dataService;

        public MainViewModel(IDataService dataService)
        {
            this._dataService = dataService;
        }

    }
}
