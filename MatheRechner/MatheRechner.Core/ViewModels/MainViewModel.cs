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



    }
}

