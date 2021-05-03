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

  public partial class Model : IOperations
  {
      public void LoadMatchList()
      {
          /* AT
          this.LoadNodesTask( );
          */
          Task.Run(() => this.LoadMatchTask());
      }

      private void LoadMatchTask()
      {
          IMatchData networkClient = NetworkClientFactory.GetNetworkClient();

          try
          {
              MatchData[] matchList = networkClient.GetMatchSelection();

              this.MatchDataList = matchList.ToList();
          }
          catch (Exception)
          {
              // ignored
          }
      }
  }
}
