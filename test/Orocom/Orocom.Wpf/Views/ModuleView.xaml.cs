using Orocom.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Orocom.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour ModuleView.xaml
    /// </summary>
    public partial class ModuleView : UserControl
    {
        public ModuleView()
        {
            InitializeComponent();
            this.DataContext = new ViewModelModuleView();
        }

        private void UpdateModuleButton_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelModuleView)this.DataContext).UpdateModule();
        }

        private void DeleteModuleButton_Click(object sender, RoutedEventArgs e)
         => ((ViewModelModuleView)this.DataContext).DeleteModule();

        private void AddModuleButton_Click(object sender, RoutedEventArgs e)
         =>   ((ViewModelModuleView)this.DataContext).AddModule();
    }
}
