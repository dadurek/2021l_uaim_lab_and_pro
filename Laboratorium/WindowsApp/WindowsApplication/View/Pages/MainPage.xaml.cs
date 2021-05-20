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

namespace WindowsApplication.View.Pages
{
    using Windows.UI.Xaml.Controls;
    using Controller;
    using global::Utilities;
    using Model;
    using Utilities;

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher();

            Controller = ControllerFactory.GetController(dispatcher);

            Model = Controller.Model;

            DataContext = Controller;
        }

        public IData Model { get; }

        public IController Controller { get; }
    }
}