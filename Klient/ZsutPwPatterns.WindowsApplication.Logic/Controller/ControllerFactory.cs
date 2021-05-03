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

namespace ZsutPwPatterns.WindowsApplication.Logic.Controller
{
    using Model;
    using Utilities;

    public static class ControllerFactory
    {
        private static IController controller;

        public static IController GetController(IEventDispatcher dispatcher)
        {
            if (controller == null)
            {
                IModel newModel = new Model(dispatcher);

                IController newController = new Controller(dispatcher, newModel);

                controller = newController;
            }

            return controller;
        }
    }
}