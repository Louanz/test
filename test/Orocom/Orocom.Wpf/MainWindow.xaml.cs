using Orocom.Wpf.ViewModels;
using Orocom.Wpf.Views;
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

namespace Orocom.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Button? SelectedButton { get; set; }


    public MainWindow()
    {
        InitializeComponent();
        SelectedButton = ButtonHome;
        this.DataContext = new ViewModelMainWindow();
    }

    private void ButtonHome_Click(object sender, RoutedEventArgs e)
    {
        MainPanel.Children.Clear();
        MainPanel.Children.Add(new HomeView());
        ChangeSelectedButton(sender as Button);
    }

    private void ButtonModule_Click(object sender, RoutedEventArgs e)
    {
        MainPanel.Children.Clear();
        MainPanel.Children.Add(new ModuleView());
        ChangeSelectedButton(sender as Button);
    }

    private void ButtonUser_Click(object sender, RoutedEventArgs e)
    {
        MainPanel.Children.Clear();
        MainPanel.Children.Add(new UserView());
        ChangeSelectedButton(sender as Button);
    }

    private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        => ((ViewModelMainWindow)this.DataContext).Logout();

    private void ButtonProducts_Click(object sender, RoutedEventArgs e)
    {
        MainPanel.Children.Clear();
        MainPanel.Children.Add(new ProductView());
        ChangeSelectedButton(sender as Button);
    }


    private void ChangeSelectedButton(Button? button)
    {
        if (SelectedButton is not null)
            SelectedButton.Background = TryFindResource("MenuButtonColor") as SolidColorBrush;

        SelectedButton = button;

        if (SelectedButton is not null)
            SelectedButton.Background = TryFindResource("MenuButtonColorSelected") as SolidColorBrush;

    }


}