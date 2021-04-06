using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace ImageGallery.Converters
{
    /// <summary>
    /// Converts the value true to false and false to true.
    /// Pattern learned form: https://stackoverflow.com/questions/55537053/convert-y-n-to-true-false-in-xaml
    /// </summary>
    public class ZeroToFalseConverter : IValueConverter
    {
        /// <summary>
        /// Converts the bool value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Int32)
            {
                return (int)value == 0;
            }
            return false;
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
