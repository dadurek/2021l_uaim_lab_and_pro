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

namespace ZsutPwPatterns.WindowsApplication.View.Converters
{
    using System;
    using Windows.UI.Xaml.Data;
    using Logic.Model.Data;

    public class MatchDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var matchData = (MatchData) value;

            return string.Format("Doctor {0} in room {1}", matchData.doctor.FirstName + " " + matchData.doctor.LastName,
                matchData.room.Number);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}