using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using WheelsForHire.Views;

namespace WheelsForHire.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            Init();
        }

        private void Init()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(HomeView));
        }

    }
}
