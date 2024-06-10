using Microsoft.AspNet.Identity;
using Orocom.DbLib.Class;
using Orocom.Wpf.Windows;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Orocom.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public User? LoggedUser { get; set; }


    public App()
    {
        using (OrocomContext? db = new())
        {
            db.Database.EnsureCreated();
            if (!db.Users.Any())
            {
                db.Users.Add(new User { Email="orocom@orocom.fr", EmailVerifiedAt=DateTime.Now, Name = "admin", Password = new PasswordHasher().HashPassword("test") });
                db.SaveChanges();
            }
        }
    }

    public void Login(User user)
    {
        LoggedUser = user;
        MainWindow mainWindow = new();
        App.Current.MainWindow.Close();
        App.Current.MainWindow = mainWindow;
        mainWindow.Show();
    }
    public void Logout()
    {
        LoggedUser = null;
        LoginWindow windowLogin = new();
        App.Current.MainWindow.Close();
        App.Current.MainWindow = windowLogin;
        windowLogin.Show();
    }
}
