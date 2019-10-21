using System;
using System.Globalization;
using Xamarin.Forms;

namespace XrnCourse.MvvmBasics.Converters
{
    public class AgeToAgeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                return $"{value} years old";
            }
            else
                throw new ArgumentException("value must be of type 'int'", "value");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
