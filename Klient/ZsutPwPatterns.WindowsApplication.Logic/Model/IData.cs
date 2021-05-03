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

namespace ZsutPwPatterns.WindowsApplication.Logic.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Data;

    public interface IData : INotifyPropertyChanged
    {
        List<MatchData> MatchDataList { get; }

        MatchData SelectedMatch { get; set; }
    }
}