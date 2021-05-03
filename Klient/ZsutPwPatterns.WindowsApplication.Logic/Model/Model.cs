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
    using Utilities;

    public partial class Model : PropertyContainerBase, IModel
    {
        public Model(IEventDispatcher dispatch) : base(dispatch)
        {
        }
    }
}