using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MatheKönig.Core
{
    
        public class MainViewCommand<T> : ICommand
        {
            #region Fields

            readonly Action<T> _execute = null;
            readonly Predicate<T> _canExecute = null;

            #endregion

            #region Constructors

            /// <summary>
            /// Initializes a new instance of <see cref="DelegateCommand{T}"/>.
            /// </summary>
            /// <param name="execute">Execute dann aufrufen wenn es auf Command aufgerufen wird</param>
            /// <remarks><seealso cref="CanExecute"/> bleibt immer true </remarks>
            public MainViewCommand(Action<T> execute)
                : this(execute, null)
            {
            }

            /// <summary>
            /// Erstellt einen neuen Command
            /// </summary>
            /// <param name="execute">Logik</param>
            /// <param name="canExecute">Status des Commands</param>
            public MainViewCommand(Action<T> execute, Predicate<T> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");

                _execute = execute;
                _canExecute = canExecute;
            }

       

        public event EventHandler CanExecuteChanged;

        #endregion

        #region ICommand Members

        ///<summary>
        ///Definiert ob der Command ausgelöst werden kann.
        ///</summary>
        ///<param name="parameter">Daten die vom Command verwendet werden. Wenn kein Datenverkehr stattfindet, set to null</param>
        ///<returns>
        ///wenn der Command ausgeführt werden kann = true, sonst false
        ///</returns>
        public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute((T)parameter);
            }



        ///<summary>
        ///Ruft die Methode auf wenn der Command aufgerufen wird.
        ///</summary>
        ///<param name="parameter">Daten die vom Command verwendet werden. Wenn kein Datenverkehr stattfindet, set to null<see langword="null" />.</param>
        public void Execute(object parameter)
            {
                _execute((T)parameter);
            }

            #endregion
        }
    }

