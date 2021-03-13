
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
        private IMvxNavigationService _navigationService;

        private MvxObservableCollection<IRechnungItem> _rechungen;

        public MvxObservableCollection<IRechnungItem> Rechnungen
        {
            get => _rechungen;
            set => SetProperty(ref _rechungen, value);
        }

        public EingabeViewModel(IMvxNavigationService navigationService, IDataService dataService)
        {
            this._navigationService = navigationService;
            this._dataService = dataService;
        }

       
    }
}
    

