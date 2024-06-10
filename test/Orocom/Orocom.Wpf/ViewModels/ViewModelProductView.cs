using Orocom.DbLib.Class;
using Orocom.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orocom.Wpf.ViewModels;

class ViewModelProductView : ObservableObject
{
    private Product? _SelectedProduct;

    private ObservableCollection<Product> _Products;

    public Product? SelectedProduct { get => _SelectedProduct; set => SetProperty(nameof(SelectedProduct), ref _SelectedProduct, value); }

    public ObservableCollection<Product> Products { get => _Products; set => SetProperty(nameof(Products), ref _Products, value); }

    public List<Module> Modules { get; set; }

    public ViewModelProductView()
    {
        using (OrocomContext context = new())
        {
            Products = new ObservableCollection<Product>(context.Products);
            Modules = context.Modules.ToList();
        }
    }

    public void AddProduct()
    {
        using (OrocomContext context = new())
        {

            Product product = new()
            {
                Name = "Nouveau produit",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Price = "0",
                Tax = "",
                ModuleId = context.Modules.First().Id

            };
            context.Add(product);
            context.SaveChanges();
            Products.Add(product);
        }
    }

    public void UpdateProduct()
    {
        using (OrocomContext context = new())
        {
            if (SelectedProduct is not null)
            {
                context.Update(SelectedProduct);
                context.SaveChanges();
            }

        }
    }

    public void DeleteProduct()
    {
        using (OrocomContext context = new())
        {
            if (SelectedProduct is not null)
            {
                context.Remove(SelectedProduct);
                context.SaveChanges();
                Products.Remove(SelectedProduct);
            }

        }
    }
}
