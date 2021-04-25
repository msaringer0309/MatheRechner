
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
using static MatheKönig.Core.ViewModels.MainViewModel;

namespace MatheKönig.Core.ViewModels
{
    public class EingabeViewModel : MvxViewModel
    {
       
        private  IDataService _dataService;
        private  IMvxNavigationService _navigationService;

        public EingabeViewModel(IMvxNavigationService navigationService, IDataService dataService)
        {
            this._navigationService = navigationService;
            this._dataService = dataService;
        }
        private MvxCommand _goToLehrerViewCommand = null;

        public MvxCommand GoToLehrerViewCommand
        {
            get
            {
                return _goToLehrerViewCommand ?? (_goToLehrerViewCommand = new MvxCommand(() =>
                {
                    this._navigationService.Navigate<MainViewModel>();
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
        
         
        private int _zahl1;
        public int Zahl1
        {
            get { return _zahl1; }
            set { _zahl1 = value; RaisePropertyChanged(() => Zahl1); }
        }
        
        private int _zahl2;

        public int Zahl2
        {
            get { return _zahl2; }
            set { _zahl2 = value; RaisePropertyChanged(() => Zahl2); }
        }
    
        private MvxCommand _randCommand = null;

        public MvxCommand RandCommand
        {
            get
            {
                return _randCommand ?? (_randCommand = new MvxCommand(ErstellungZahl));
            }
        }

        private bool _rand = false;
        public bool Rand
        {
            get => _rand;
            set => SetProperty(ref _rand, value);
        }

        public void ErstellungZahl()
        {
            Random gen = new Random();
            this.Zahl1 = gen.Next(2, 10);
            this.Zahl2 = gen.Next(2, 10);
            this.Erg = this.Zahl1 * this.Zahl2;
        }

        private int _erg;
        public int Erg
        {
            get => _erg;
            set => SetProperty(ref _erg, value);
        }

        private MvxCommand _ergCommand = null;
        public MvxCommand ErgCommand
        {
            get
            {
                return _ergCommand ?? (_ergCommand = new MvxCommand(ErstellungZahl));
            }
        }
        private MvxCommand _checkresult;

        public MvxCommand Checkresult
        {
            get
            {
                return _checkresult ?? (_checkresult = new MvxCommand(RichtigGelöst));
            }
        }

        
        public int Eingabe
        {
            get
            {
                return this._eingabe;
            }
            set
            {
                //this._name = value;
                //RaisePropertyChanged(() => Name);
                SetProperty(ref _eingabe, value);
                MainViewCommand.RaiseCanExecuteChanged();
            }
        }

        public void RichtigGelöst()
        {
            Random gen = new Random();
            this.Zahl1 = gen.Next(2, 10);
            this.Zahl2 = gen.Next(2, 10);
            this.Erg = this.Zahl1 * this.Zahl2;

            
        
            if (this.Erg == this.Eingabe)
            {
              
                this.Anzahl = Anzahl + 1;
                this.Richtig = Richtig + 1;
               

            }
            else 
            {

                this.Anzahl = Anzahl + 1;
                this.Falsch = Falsch + 1;

            }
        }
        
        private int _anzahlaufgaben;

        public int Anzahl
        {
            get { return _anzahlaufgaben; }
            set { _anzahlaufgaben = value; RaisePropertyChanged(() => Anzahl); Checkresult.RaiseCanExecuteChanged(); }
        }

        private int _richtiggelöst;

        public int Richtig
        {
            get { return _richtiggelöst; }
            set { _richtiggelöst = value; RaisePropertyChanged(() => Richtig); Checkresult.RaiseCanExecuteChanged(); }
        }

        private int _falschgelöst;

        public int Falsch
        {
            get { return _falschgelöst; }
            set { _falschgelöst = value; RaisePropertyChanged(() => Falsch); Checkresult.RaiseCanExecuteChanged(); }
        }

    }
}
    

