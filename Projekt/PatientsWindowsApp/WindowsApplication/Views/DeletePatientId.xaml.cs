// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientUWP.Views
{
    using Windows.UI.Xaml.Controls;
    using Controller;
    using global::Utilities;
    using Utilities;

    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DeletePatientId : Page
    {
        public DeletePatientId()
        {
            InitializeComponent();

            var dispatcher = new EventDispatcher() as IEventDispatcher;

            Controller = ControllerFactory.GetController(dispatcher);

            DataContext = Controller;
        }

        public IController Controller { get; }

        private void Id_TextChanged(object sender, TextChangedEventArgs e)
        {
            Controller.PatientModel.SearchTextDeleteId = searchText.Text;
        }
    }
}