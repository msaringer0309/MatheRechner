
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
        public EingabeViewModel()
        {
            GenZahl2();
            GenZahl1();
        }
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

        /* public override async Task Initialize()
         {
             await base.Initialize();

             var rechnungen = _dataService.All();

             Rechnungen = new MvxObservableCollection<IRechnungItem>(rechnungen);
         }
         */
        private int _zahl1;
        public int Zahl1
        {
            get { return _zahl1; }
            set { _zahl1 = value; RaisePropertyChanged(() => Zahl1); }
        }
        public void GenZahl1()
        {
            Random r = new Random();
            this._zahl1 = r.Next(1, 10);
        }

        private int _zahl2;

        public int Zahl2
        {
            get { return _zahl2; }
            set { _zahl2 = value; RaisePropertyChanged(() => Zahl2); }
        }
        public void GenZahl2()
        {
            Random r = new Random();
            this.Zahl2 = r.Next(0, 10);
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

        private void ErstellungZahl()
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
        public MvxCommand Checkresult
        {
            get
            {
                return _ergCommand ?? (_ergCommand = new MvxCommand(RichtigGelöst));
            }
        }
        public int Eingabe = 0;
        int richtigcounter = 0;
        int falschcounter = 0;
        int anzahlaufgaben = 1;


        public void RichtigGelöst()
        {
            if (this.Eingabe == this.Zahl1 * this.Zahl2)
            {
                richtigcounter = richtigcounter + 1;
                anzahlaufgaben = anzahlaufgaben + 1;

            }
            else
            {

                falschcounter = falschcounter + 1;
                anzahlaufgaben = anzahlaufgaben + 1;

            }
        }

        public int Richtig
        {
            get { return richtigcounter; }
            set { richtigcounter = value; RaisePropertyChanged(() => richtigcounter); }
        }
        public int Falsch
        {
            get { return falschcounter; }
            set { falschcounter = value; RaisePropertyChanged(() => falschcounter); }
        }
        public int Anzahl
        {
            get { return anzahlaufgaben; }
            set { anzahlaufgaben = value; RaisePropertyChanged(() => anzahlaufgaben); }
        }
    }
}
    

