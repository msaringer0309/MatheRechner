using MvvmCross.Logging;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.ViewModels;

namespace MatheRechner.WpfApp
{
    public class Setup : MvxWpfSetup
    {
        protected override IMvxApplication CreateApp()
        { 
            return new MatheRechner.Core.Setup(); 

        }

        public override MvxLogProviderType 
            GetDefaultLogProviderType() => MvxLogProviderType.NLog;

    }
}
