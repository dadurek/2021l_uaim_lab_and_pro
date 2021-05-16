namespace ClientUWP.Utilities
{
    using System;
    using System.Collections.Generic;
    using Windows.UI.Xaml.Data;
    using Model.Dto;

    class SpecializationListToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (List<SpecializationDto>) value;
            var ret = "";
            date.ForEach(x =>
            {
                ret += x.ToString();
                ret += "; ";
            });
            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}