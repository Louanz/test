using Orocom.DbLib.Class;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Orocom.Wpf.Converters;

class RoleToVisibilityConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Visibility visibility = Visibility.Collapsed;
        bool isRoleValid = false;
        try
        {
            isRoleValid = true;//((User)value).?.Contains((string)parameter) ?? false;
        }
        catch (Exception ex)
        {
            throw new Exception("Erreur de conversion de l'utilisateur, ou rôle inexistant", ex);
        }

        if (isRoleValid && value != null && value != DependencyProperty.UnsetValue)
            visibility = Visibility.Visible;

        return visibility;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
