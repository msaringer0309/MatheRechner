using MvvmCross;
using MvvmCross.ViewModels;
using MatheKönig.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Mathekönig.Services;
using MatheKönig.Core.Services;
using MvvmCross.IoC;

namespace MatheKönig.Core
{
    public class Setup : MvxApplication
    {
        public override void Initialize()
        {

            Mvx.IoCProvider.RegisterType<IDataService>();
            Mvx.IoCProvider.RegisterSingleton<IDataService>(new SqlData());



            RegisterAppStart<MainViewModel>();
        }
    }
}
