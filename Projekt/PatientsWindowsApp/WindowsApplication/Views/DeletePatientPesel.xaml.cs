namespace ClientUWP.Views
{
    using Windows.UI.Xaml.Controls;
    using Controller;
    using global::Utilities;
    using Utilities;

    public sealed partial class DeletePatientPesel : Page
    {
        public DeletePatientPesel()
        {
            InitializeComponent();

            var dispatcher = new EventDispatcher() as IEventDispatcher;

            Controller = ControllerFactory.GetController(dispatcher);

            DataContext = Controller;
        }

        public IController Controller { get; }

        private void Pesel_TextChanged(object sender, TextChangedEventArgs e)
        {
            Controller.PatientModel.SearchTextDeletePesel = searchText.Text;
        }
    }
}