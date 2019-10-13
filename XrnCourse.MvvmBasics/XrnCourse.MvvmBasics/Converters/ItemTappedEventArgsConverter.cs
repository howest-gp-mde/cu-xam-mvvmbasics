using System;
using System.Globalization;
using Xamarin.Forms;

namespace XrnCourse.MvvmBasics.Converters
{
    /// <summary>
    /// Ensures the Convert method returns an ItemTappedEventArgs.Items instance instead of the EventArgs.
    /// </summary>
    public class ItemTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as ItemTappedEventArgs;
            if (eventArgs == null)
                throw new ArgumentException("Expected TappedEventArgs as value", "value");
            //Item contains the tapped item, in our case this will be a Classmate instance
            return eventArgs.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); //not needed or used
        }
    }

}
