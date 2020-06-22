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
using WheelsForHire.Interfaces;
using WheelsForHire.Services;
using WheelsForHire.Factories;

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

            containerRegistry.Register<IVehicleAvailabilityService, VehicleAvailabilityService>();
            containerRegistry.Register<IVehiclePriceCalculatorService, VehiclePriceCalculatorService>();
            containerRegistry.Register<IDamageDepositModelFactory, DamageDepositModelFactory>();

            containerRegistry.RegisterForNavigation<HomeView>("Home");
            containerRegistry.RegisterForNavigation<FunctionSelectView>("FunctionSelect");
            containerRegistry.RegisterForNavigation<AddStockView>("AddStock");
            containerRegistry.RegisterForNavigation<NewBookingView>("NewBooking");
            containerRegistry.RegisterForNavigation<AdHocView>("AdHoc");
            containerRegistry.RegisterForNavigation<EquipmentSalesView>("NewSale");
            containerRegistry.RegisterForNavigation<InsuranceView>("Insurance");
            containerRegistry.RegisterForNavigation<UsersPoliciesView>("UserPolicy");
            containerRegistry.RegisterForNavigation<ManageDepositsView>("DamageDeposits");
        }

        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

    }
}
