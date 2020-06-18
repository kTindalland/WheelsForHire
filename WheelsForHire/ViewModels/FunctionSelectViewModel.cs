using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WheelsForHire.ViewModels
{
    public class FunctionSelectViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public ICommand BackToSplashCommand { get; set; }
        public ICommand AddStockCommand { get; set; }

        public ICommand ToNewBookingCommand { get; set; }

        public ICommand ToAdHocCommand { get; set; }

        public FunctionSelectViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            BackToSplashCommand = new DelegateCommand(BackToSplash);
            AddStockCommand = new DelegateCommand(AddStock);
            ToNewBookingCommand = new DelegateCommand(ToNewBooking);
            ToAdHocCommand = new DelegateCommand(ToAdHoc);
        }

        private void ToAdHoc()
        {
            _regionManager.RequestNavigate("MainRegion", "AdHoc");
        }

        private void ToNewBooking()
        {
            _regionManager.RequestNavigate("MainRegion", "NewBooking");
        }

        private void BackToSplash()
        {
            _regionManager.RequestNavigate("MainRegion", "Home");
        }

        private void AddStock()
        {
            _regionManager.RequestNavigate("MainRegion", "AddStock");
        }
    }


}
