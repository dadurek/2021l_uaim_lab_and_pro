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

namespace ZsutPwPatterns.WindowsApplication.Logic.Utilities
{
    using System;
    using System.ComponentModel;

    public class PropertyContainerBase : INotifyPropertyChanged
    {
        protected readonly IEventDispatcher dispatcher;

        protected PropertyContainerBase(IEventDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                var args = new PropertyChangedEventArgs(propertyName);

                /* AT
                handler( this, args );
                */
                Action action = () => handler(this, args);

                dispatcher.Dispatch(action);
            }
        }
    }
}