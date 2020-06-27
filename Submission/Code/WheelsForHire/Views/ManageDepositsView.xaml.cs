using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WheelsForHire.ViewModels;

namespace WheelsForHire.Views
{
    /// <summary>
    /// Interaction logic for ManageDepositsView.xaml
    /// </summary>
    public partial class ManageDepositsView : UserControl
    {
        public ManageDepositsView(ManageDepositsViewModel viewmodel)
        {
            DataContext = viewmodel;
            InitializeComponent();
        }
    }
}
