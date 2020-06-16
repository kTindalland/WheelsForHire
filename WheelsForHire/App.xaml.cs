using CommonServiceLocator;
using Database;
using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WheelsForHire.Views;

namespace WheelsForHire
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<WheelsContext, WheelsContext>();

            containerRegistry.RegisterForNavigation<HomeView>("Home");
            containerRegistry.RegisterForNavigation<FunctionSelectView>("FunctionSelect");
            containerRegistry.RegisterForNavigation<AddStockView>("AddStock");
        }

        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

    }
}
