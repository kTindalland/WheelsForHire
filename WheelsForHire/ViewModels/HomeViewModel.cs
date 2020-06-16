using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows.Input;

namespace WheelsForHire.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public ICommand EnterApplicationCommand { get; set; }

        public HomeViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            EnterApplicationCommand = new DelegateCommand(EnterApplication);
        }

        private void EnterApplication()
        {
            _regionManager.RequestNavigate("MainRegion", "FunctionSelect");
        }
    }
}
