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
        public ICommand ToNewSaleCommand { get; set; }
        public ICommand ToInsuranceCommand { get; set; }
        public ICommand ToDamageDepositCommand { get; set; }

        public FunctionSelectViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            BackToSplashCommand = new DelegateCommand(BackToSplash);
            AddStockCommand = new DelegateCommand(AddStock);
            ToNewBookingCommand = new DelegateCommand(ToNewBooking);
            ToAdHocCommand = new DelegateCommand(ToAdHoc);
            ToNewSaleCommand = new DelegateCommand(ToNewSale);
            ToInsuranceCommand = new DelegateCommand(ToInsurance);
            ToDamageDepositCommand = new DelegateCommand(ToDamageDeposits);
        }

        private void ToDamageDeposits()
        {
            _regionManager.RequestNavigate("MainRegion", "DamageDeposits");
        }

        private void ToInsurance()
        {
            _regionManager.RequestNavigate("MainRegion", "Insurance");
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

        private void ToNewSale()
        {
            _regionManager.RequestNavigate("MainRegion", "NewSale");
        }
    }


}
