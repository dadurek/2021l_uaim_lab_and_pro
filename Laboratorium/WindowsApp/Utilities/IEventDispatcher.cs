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

namespace Utilities
{
    using System;

    public interface IEventDispatcher
    {
        void Dispatch(Action eventAction);
    }
}