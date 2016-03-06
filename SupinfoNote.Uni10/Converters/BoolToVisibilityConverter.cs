﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SupinfoNote.Uni10.Converters
{
  public  class BoolToVisibilityConverter: IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, string language)
      {
          bool isVisible = (bool) value;
          return isVisible ? Visibility.Visible : Visibility.Collapsed;
      }

      public object ConvertBack(object value, Type targetType, object parameter, string language)
      {
          throw new NotImplementedException();
      }
    }
}
