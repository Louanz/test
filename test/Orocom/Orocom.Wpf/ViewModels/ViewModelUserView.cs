using Microsoft.AspNet.Identity;
using Orocom.DbLib.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orocom.Wpf.ViewModels;

public class ViewModelUserView
{
    public ObservableCollection<User> Users { get; set; }

    public User? SelectedUser { get; set; }

    public string? UnhashedPassword { get; set; }

    private PasswordHasher _Hasher { get; set; }

    public ViewModelUserView()
    {
        _Hasher = new();
        using (OrocomContext context = new())
            Users = new ObservableCollection<User>(context.Users);

    }

    public void AddUser()
    {
        UnhashedPassword = "Password";
        using (OrocomContext context = new())
        {
            User user = new User()
            {
                Name = "Nouvel Utilisateur",
                Password = _Hasher.HashPassword(UnhashedPassword),
                Email = "toupdate@orocom.fr",
                EmailVerifiedAt = DateTime.Now
                // = "USER"
            };
            context.Users.Add(user);
            context.SaveChanges();
            Users.Add(user);
            SelectedUser = null;
            SelectedUser = user;
        }
    }

    public void RemoveUser()
    {
        using (OrocomContext context = new())
        {
            if (SelectedUser is not null)
            {
                context.Users.Remove(SelectedUser);
                context.SaveChanges();
                Users.Remove(SelectedUser);
                SelectedUser = null;
            }
        }
    }

    public void UpdateUser()
    {
        using (OrocomContext context = new())
        {
            if (SelectedUser is not null)
            {
                if (!string.IsNullOrWhiteSpace(UnhashedPassword))
                    SelectedUser.Password = _Hasher.HashPassword(UnhashedPassword);
                context.Users.Update(SelectedUser);
                context.SaveChanges();
            }

        }
    }
}
