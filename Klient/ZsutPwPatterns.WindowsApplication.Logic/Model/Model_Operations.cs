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
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Service;

    public partial class Model : IOperations
    {
        public void LoadMatchList()
        {
            Task.Run(() => LoadMatchTask());
        }

        private void LoadMatchTask()
        {
            var networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                var matchList = networkClient.GetMatchSelection();

                MatchDataList = matchList.ToList();
            }
            catch (Exception)
            {
            }
        }
    }
}