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
    using Data;

    public partial class Model : IData
    {
        private List<MatchData> roomList = new List<MatchData>();

        private MatchData selectedRoom;

        public List<MatchData> MatchDataList
        {
            get => roomList;
            private set
            {
                roomList = value;

                RaisePropertyChanged("MatchDataList");
            }
        }

        public MatchData SelectedMatch
        {
            get => selectedRoom;
            set
            {
                selectedRoom = value;

                RaisePropertyChanged("SelectedMatch");
            }
        }
    }
}