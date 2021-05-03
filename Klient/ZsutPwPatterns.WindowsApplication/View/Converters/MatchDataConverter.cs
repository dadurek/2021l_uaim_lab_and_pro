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

namespace ZsutPw.Patterns.WindowsApplication.View
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Windows.UI.Xaml.Data;
  using Logic.Model.Data;
  using ZsutPw.Patterns.WindowsApplication.Model;

  public class MatchDataConverter : IValueConverter
  {
    public object Convert( object value, Type targetType, object parameter, string language )
    {
      MatchData matchData = (MatchData)value;

      return String.Format( "Doctor {0} in room {1}", matchData.DoctorName, matchData.RoomNumber );
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
      throw new NotImplementedException( );
    }
  }
}
