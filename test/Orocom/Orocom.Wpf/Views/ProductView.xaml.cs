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
    /// Logique d'interaction pour ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
            this.DataContext = new ViewModelProductView();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
         =>   ((ViewModelProductView)this.DataContext).AddProduct();

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
         => ((ViewModelProductView)this.DataContext).DeleteProduct();

        private void UpdateProductButton_Click(object sender, RoutedEventArgs e)
         => ((ViewModelProductView)this.DataContext).UpdateProduct();
    }
}
