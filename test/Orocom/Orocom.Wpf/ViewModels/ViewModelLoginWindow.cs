using Microsoft.AspNet.Identity;
using Orocom.DbLib.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orocom.Wpf.ViewModels;

public class ViewModelLoginWindow
{
    public string? UserName { get; set; }

    public string? Password { get; set; }

    private PasswordHasher _Hasher { get; set; }

    public ViewModelLoginWindow()
    {
        _Hasher = new();
    }

    public void Login()
    {
        User? user = null;
        PasswordVerificationResult result = PasswordVerificationResult.Failed;
        using (OrocomContext context = new())
            user = context.Users
                .FirstOrDefault(userTemp => userTemp.Name.Equals(UserName));

        if (user is not null)
        {
            result = _Hasher.VerifyHashedPassword(user.Password, Password);
            if (result == PasswordVerificationResult.Success)
                ((App)App.Current).Login(user);
        }
    }
}
