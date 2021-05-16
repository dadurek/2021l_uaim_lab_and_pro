namespace ClientUWP.Utilities
{
    using System;
    using Windows.UI.Xaml.Data;

    public class DateTimeToDateTimeOffset : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                var date = (DateTime) value;
                return new DateTimeOffset(date);
            }
            catch (Exception)
            {
                return DateTimeOffset.MinValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var dto = (DateTimeOffset) value;
            try
            {
                return dto.DateTime;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }
    }
}