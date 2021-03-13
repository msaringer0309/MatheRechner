
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
using System.Threading.Tasks;

namespace MatheKönig.Core.ViewModels
{
    public class EingabeViewModel : MvxViewModel 
    {

        private protected IDataService _dataService;
        private protected IMvxNavigationService _navigationService;

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

        private MvxCommand _backCommand = null;

        public MvxCommand GoBackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new MvxCommand(() =>
                {
                    this._navigationService.Close(this);
                }));
            }
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            var rechnungen = _dataService.All();

            Rechnungen = new MvxObservableCollection<IRechnungItem>(rechnungen);
        }
       
    }
}
    

