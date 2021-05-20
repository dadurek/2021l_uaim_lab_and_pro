//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace WindowsApplication.View.Converters
{
    using System;
    using Windows.UI.Xaml.Data;
    using Controller;

    public class ApplicationStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var applicationState = (ApplicationState) value;

            var applicationStateName = applicationState.ToString();

            return applicationStateName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var applicationStateName = (string) value;

            var applicationState = (ApplicationState) Enum.Parse(typeof(ApplicationState), applicationStateName);

            return applicationState;
        }
    }
}