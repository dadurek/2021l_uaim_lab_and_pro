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
    using Model;
    using Utilities;

    public partial class Controller : PropertyContainerBase, IController
    {
        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            Model = model;

            SearchMatchesCommand = new ControllerCommand(SearchMatches);

            ShowListCommand = new ControllerCommand(ShowList);

            ShowMapCommand = new ControllerCommand(ShowMap);
        }

        public IModel Model { get; }
    }
}