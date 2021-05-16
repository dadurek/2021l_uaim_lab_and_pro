// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientUWP.Views
{
    using Windows.UI.Xaml.Controls;
    using Controller;
    using global::Utilities;
    using Model.IData;
    using Utilities;

    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher();

            Controller = ControllerFactory.GetController(dispatcher);
            DoctorData = Controller.DoctorModel;
            DataContext = Controller;
        }

        public IDoctorData DoctorData { get; }

        public IController Controller { get; }
    }
}