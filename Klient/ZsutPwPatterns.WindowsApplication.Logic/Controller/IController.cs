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
    using System.ComponentModel;
    using System.Windows.Input;
    using Model;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ApplicationState CurrentState { get; }

        ICommand SearchMatchesCommand { get; }

        ICommand ShowListCommand { get; }

        ICommand ShowMapCommand { get; }
    }
}