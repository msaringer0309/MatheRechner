using MvvmCross.Logging;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.ViewModels;

namespace MatheKönig.WpfApp
{
    public class Setup : MvxWpfSetup
    {
        protected override IMvxApplication CreateApp()
        { 
            return new MatheKönig.Core.Setup(); 

        }

        public override MvxLogProviderType 
            GetDefaultLogProviderType() => MvxLogProviderType.NLog;

    }
}
