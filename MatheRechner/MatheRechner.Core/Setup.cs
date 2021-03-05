using MvvmCross;
using MvvmCross.ViewModels;
using MatheRechner.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatheRechner.Core
{
    public class Setup : MvxApplication
    {
        public override void Initialize()
        {
           

            RegisterAppStart<MainViewModel>();
        }
    }
}
