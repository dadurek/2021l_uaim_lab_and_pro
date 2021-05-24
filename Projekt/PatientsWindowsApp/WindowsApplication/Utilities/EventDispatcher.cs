namespace ClientUWP.Utilities
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
            void DispatchedHandler() =>
                eventAction();

            var dispatcher = GetCoreDispatcher();

            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, DispatchedHandler);
        }

        public void Dispatch2(Action eventAction)
        {
            void DispatchedHandler() =>
                eventAction();

            var dispatcher = GetCoreDispatcher();

            async void Action() =>
                await dispatcher.RunAsync(CoreDispatcherPriority.Normal, DispatchedHandler);

            Task.Run(Action);
        }

        #endregion
    }
}