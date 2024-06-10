using Microsoft.EntityFrameworkCore;
using Orocom.DbLib.Class;
using Orocom.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orocom.Wpf.ViewModels;

public class ViewModelModuleView
{
    public ObservableCollection<Module> Modules { get; set; }

    public Module? SelectedModule { get; set; }

    public ViewModelModuleView()
    {
        Modules = new ObservableCollection<Module>();
        LoadModules();
    }

    private void LoadModules()
    {
        using (OrocomContext context = new())
        {
            Modules.Clear();
            Modules = new ObservableCollection<Module>(context.Modules);
        }
    }

    public void AddModule()
    {
        Module module = new();
        module.CreatedAt = DateTime.Now;
        module.UpdatedAt = DateTime.Now;
        module.Title = "Nouveau module";

        using (OrocomContext context = new())
        {
            context.Add(module);
            Modules.Add(module);
            context.SaveChanges();
        }
    }

    public void UpdateModule()
    {
        using (OrocomContext context = new())
        {
            if (SelectedModule is not null)
            {
                context.Update(SelectedModule);
                context.SaveChanges();
            }
        }
    }

    public void DeleteModule()
    {
        using (OrocomContext context = new())
        {
            if (SelectedModule is not null)
            {
                context.Remove(SelectedModule);
                context.SaveChanges();
                Modules.Remove(SelectedModule);
            }
        }
    }

}
