﻿using Prism.Commands;
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

        public FunctionSelectViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            BackToSplashCommand = new DelegateCommand(BackToSplash);
        }

        private void BackToSplash()
        {
            _regionManager.RequestNavigate("MainRegion", "Home");
        }
    }


}