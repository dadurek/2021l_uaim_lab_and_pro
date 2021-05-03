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

namespace ZsutPw.Patterns.WindowsApplication.Model
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using Logic.Model.Data;

  public partial class Model : IData
  {
        public List<MatchData> MatchDataList
        {
            get { return this.roomList; }
            private set
            {
                this.roomList = value;

                this.RaisePropertyChanged("MatchDataList");
            }
        }
        private List<MatchData> roomList = new List<MatchData>();

        public MatchData SelectedMatch
        {
            get { return this.selectedRoom; }
            set
            {
                this.selectedRoom = value;

                this.RaisePropertyChanged("SelectedMatch");
            }
        }
        private MatchData selectedRoom;
    }
}
