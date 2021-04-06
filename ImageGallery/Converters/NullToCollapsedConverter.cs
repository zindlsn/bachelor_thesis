using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ImageGallery.Converters
{
    /// <summary>
    /// Converts null to Visibility.
    /// Template from: https://stackoverflow.com/questions/21939667/nulltovisibilityconverter-make-visible-if-not-null
    /// </summary>
    public class NullToCollapsedConverter : IValueConverter
    {
        /// <summary>
        /// Converts null to Visibility.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool visible = true;
            if (value == null)
            {
                visible = false;
            }
            if(value is bool)
            {
                visible =(bool)value;
            }
            if (value is Int32)
            {
                if ((Int32)value == 0)
                {
                    visible = false;
                }
            }
            return visible ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Not needed.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
