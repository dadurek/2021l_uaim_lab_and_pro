namespace ClientUWP.Views
{
    using Windows.UI.Xaml.Controls;
    using Controller;
    using global::Utilities;
    using Utilities;

    public sealed partial class Doctors : Page
    {
        public Doctors()
        {
            InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher();

            Controller = ControllerFactory.GetController(dispatcher);

            DataContext = Controller;
        }

        public IController Controller { get; }
    }
}