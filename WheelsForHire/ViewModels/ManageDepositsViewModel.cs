using Database;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WheelsForHire.ViewModels
{
    public class ManageDepositsViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly WheelsContext _context;

        public ICommand BackCommand { get; set; }
        public ICommand SearchUserCommand { get; set; }
        public ICommand ShowUnpaidCommand { get; set; }
        public ICommand ShowNotRefundedCommand { get; set; }
        

        public ManageDepositsViewModel(
            IRegionManager regionManager,
            WheelsContext context)
        {
            _regionManager = regionManager;
            _context = context;
        }

    }
}
