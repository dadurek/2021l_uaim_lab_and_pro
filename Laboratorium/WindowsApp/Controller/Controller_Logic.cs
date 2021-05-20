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

namespace Controller
{
    using System.Windows.Input;

    public partial class Controller : IController
    {
        private ApplicationState currentState = ApplicationState.List;

        public ApplicationState CurrentState
        {
            get => currentState;
            set
            {
                currentState = value;

                RaisePropertyChanged("CurrentState");
            }
        }

        public ICommand SearchMatchesCommand { get; }

        public ICommand ShowListCommand { get; }

        public ICommand ShowMapCommand { get; }

        private void SearchMatches()
        {
            Model.LoadMatchList();
        }

        private void ShowList()
        {
            switch (CurrentState)
            {
                case ApplicationState.List:
                    break;

                default:
                    CurrentState = ApplicationState.List;
                    break;
            }
        }

        private void ShowMap()
        {
            switch (CurrentState)
            {
                case ApplicationState.Map:
                    break;

                default:
                    CurrentState = ApplicationState.Map;
                    break;
            }
        }
    }
}