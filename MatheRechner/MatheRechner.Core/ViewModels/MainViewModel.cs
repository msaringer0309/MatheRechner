using System;
using MvvmCross.ViewModels;
using System.Windows.Input;


namespace MatheKönig.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public class ViewModel 
        {
            public Calculator Calculator { get; set; }

            public ViewModel()
            {
                this.Calculator = new Calculator();

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

        private int _zahl1;
        public int Zahl1
        {​​​​​​​
            get => _zahl1;
            set => SetProperty(ref _zahl1, value);
        }​​​​​​​
        public void GenZahl1()
        {
            Random r = new Random();
            this._zahl1 = r.Next(1, 10);
        }

        private int _zahl2;
        public int Zahl2
        {​​​​​​​
            get => _zahl2;
            set => SetProperty(ref _zahl2, value);
        }​​​​​​​
        public void GenZahl2()
        {
            Random r = new Random();
            this._zahl2 = r.Next(1, 10);
        }

    }
}

