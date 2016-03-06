using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using SupinfoNote.Uni10.ViewModel;

namespace SupinfoNote.Uni10.Converters
{
   public  class TypeEqualConverter:IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, string language)
       {
           var actualType = value as Type;
           var buttonType = parameter as NavType;
           if (actualType != null && buttonType !=null)
           {
               return actualType.FullName == buttonType.Type.FullName;
           }
           return false;
       }

       public object ConvertBack(object value, Type targetType, object parameter, string language)
       {
           throw new NotImplementedException();
       }
    }
}
