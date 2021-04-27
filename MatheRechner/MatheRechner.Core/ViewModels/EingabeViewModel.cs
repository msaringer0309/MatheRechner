
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
       
        private  IDataService _dataService;
        private  IMvxNavigationService _navigationService;

        public EingabeViewModel(IMvxNavigationService navigationService, IDataService dataService)
        {
            
            this._navigationService = navigationService;
            this._dataService = dataService;
        }


        private MvxCommand _SaveResult;

        public MvxCommand SaveResult
        {
            get
            {
                return _SaveResult ?? (_SaveResult = new MvxCommand(SaveData, CanGenerateData));
            }
        }

        private void SaveData()
        {
            RechnungItem r = new RechnungItem();
            r.Richtige = this.Richtig;
            r.Falsche = this.Falsch;
            r.Name = this.NameSave;
            r.GeneratedDateTime = DateTime.Now;
            this._dataService.Add(r);
        }

        private void Rechnungserstellung()
        {
            Random gen = new Random();
            this.Zahl1 = gen.Next(2, 10);
            this.Zahl2 = this.ChooseMalreihe;
            this.Erg = this.Zahl1 * this.Zahl2;
        }

        private bool CanGenerateData()
        {
            return this.NameSave?.Length > 0;
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
    
       

        private bool _rand = false;
        public bool Rand
        {
            get => _rand;
            set => SetProperty(ref _rand, value);
        }



        private int _Erg;
        public int Erg
        {
            get
            {
                return _Erg;
            }
            set
            {
                _Erg = value;
                RaisePropertyChanged(() => Erg);
                Checkresult.RaiseCanExecuteChanged();
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
        private int _Eingabe;
        public int Eingabe
        {
            get
            {
                return _Eingabe;
            }
            set
            {
                _Eingabe = value;
                RaisePropertyChanged(() => Eingabe);
                Checkresult.RaiseCanExecuteChanged();

            }
        }

        public void RichtigGelöst()
        {
            
            if (this.Eingabe == this.Erg)
            {
              
                this.Anzahl = Anzahl + 1;
                this.Richtig = Richtig + 1;
                Rechnungserstellung();

            }
            else
            {

                this.Anzahl = Anzahl + 1;
                this.Falsch = Falsch + 1;
                Rechnungserstellung();

            }
            this.Eingabe = 0;
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

        private string _NameSave;
        public string NameSave
        {
            get
            {
                return _NameSave;
            }
            set
            {
                _NameSave = value;
                RaisePropertyChanged(() => NameSave);
                SaveResult.RaiseCanExecuteChanged();

            }
        }

        private int _ChooseMalreihe;
        public int ChooseMalreihe
        {
            get
            {
                return _ChooseMalreihe;
            }
            set
            {
                _ChooseMalreihe = value;
                RaisePropertyChanged(() => ChooseMalreihe);
                SetMalreihe.RaiseCanExecuteChanged();

            }
        }

        private bool CanSaveMalreihe()
        {
            return this.ChooseMalreihe > 0 & this.ChooseMalreihe < 11;
        }


        private MvxCommand _SetMalreihe;

        public MvxCommand SetMalreihe
        {
            get
            {
                return _SetMalreihe ?? (_SetMalreihe = new MvxCommand(SaveMalreihe, CanSaveMalreihe));
            }
        }

        private void SaveMalreihe()
        {
            Rechnungserstellung();
            this.Visibility = "Hidden";
        }
        
        private string _Visibility;
        public string Visibility
        {
            get
            {
                return _Visibility;
            }
            set
            {
                _Visibility = value;
                RaisePropertyChanged(() => Visibility);
                

            }
        }
    }
}
    

