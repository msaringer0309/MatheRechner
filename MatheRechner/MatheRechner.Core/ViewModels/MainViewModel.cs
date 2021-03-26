using System;
using MvvmCross.ViewModels;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System.Threading.Tasks;
using Mathekönig.Models;
using Mathekönig.Services;

namespace MatheKönig.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public class ViewModel : MvxViewModel
        {
            private IMvxNavigationService _navService;
            private IDataService _dataService;

            public Calculator Calculator { get; set; }

            public ViewModel(IMvxNavigationService navService, IDataService dataService)
            {
                this._navService = navService;
                this._dataService = dataService;
                this.Calculator = new Calculator();

            }

            private MvxCommand _goBackCommand = null;
            public MvxCommand GoBackCommand
            {
                get
                {
                    return _goBackCommand ?? (_goBackCommand = new MvxCommand(() =>
                    {
                        this._navService.Close(this);
                    }));
                }
            }

            private MvxObservableCollection<IRechnungItem> _rechungen;

            public MvxObservableCollection<IRechnungItem> Rechnungen
            {
                get => _rechungen;
                set => SetProperty(ref _rechungen, value);
            }
            public override async Task Initialize()
            {
                await base.Initialize();

                var rechnungen = _dataService.All();

                Rechnungen = new MvxObservableCollection<IRechnungItem>(rechnungen);
            }





            private ICommand numberCommand;

            public ICommand NumberCommand
            {
                get
                {
                    return this.numberCommand
                           ?? (this.numberCommand = new MainViewCommand<string>(this.NumberClicked));
                }
            }

            private ICommand operationCommand;

            public ICommand OperationCommand
            {
                get
                {
                    return this.operationCommand
                           ?? (this.operationCommand = new MainViewCommand<string>(this.OperationClicked));
                }
            }

            private void OperationClicked(string operation)
            {
                this.Calculator.SetOperation(operation);
                this.OnPropertyChanged("Calculator");
            }

            private void OnPropertyChanged(string v)
            {
                throw new NotImplementedException();
            }

            private void NumberClicked(string number)
            {
                this.Calculator.ExpandNumber(number[0]);
                this.OnPropertyChanged("Calculator");
            }
  
       }



    }
}

