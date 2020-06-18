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
    /// Interaction logic for AdHocView.xaml
    /// </summary>
    public partial class AdHocView : UserControl
    {
        public AdHocView(AdHocViewModel viewmodel)
        {
            DataContext = viewmodel;
            InitializeComponent();
        }
    }
}
