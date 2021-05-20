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

namespace WindowsApplication.Utilities
{
    using System;
    using System.Threading.Tasks;
    using Windows.ApplicationModel.Core;
    using Windows.UI.Core;
    using global::Utilities;

    public class EventDispatcher : IEventDispatcher
    {
        private CoreDispatcher GetCoreDispatcher()
        {
            return CoreApplication.MainView.CoreWindow.Dispatcher;
        }

        #region IEventDispatcher

        public async void Dispatch(Action eventAction)
        {
            DispatchedHandler dispatchedHandler = () => eventAction();

            var dispatcher = GetCoreDispatcher();

            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, dispatchedHandler);
        }

        public void Dispatch2(Action eventAction)
        {
            DispatchedHandler dispatchedHandler = () => eventAction();

            var dispatcher = GetCoreDispatcher();

            Action action = async () => await dispatcher.RunAsync(CoreDispatcherPriority.Normal, dispatchedHandler);

            Task.Run(action);
        }

        #endregion
    }
}