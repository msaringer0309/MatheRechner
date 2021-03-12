using MvvmCross;
using MvvmCross.ViewModels;
using MatheKönig.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;



namespace MatheKönig.Core
{
    public class Setup : MvxApplication
    {
        public override void Initialize()
        {
    
            
            
           

            RegisterAppStart<EingabeViewModel>();
        }
    }
}
