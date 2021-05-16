// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientUWP.Views
{
    using Windows.UI.Xaml.Controls;
    using Controller;
    using global::Utilities;
    using Model.IData;
    using Utilities;

    public sealed partial class PatientId : Page
    {
        public PatientId()
        {
            InitializeComponent();

            var dispatcher = new EventDispatcher() as IEventDispatcher;

            Controller = ControllerFactory.GetController(dispatcher);
            PatientData = Controller.PatientModel;
            DataContext = Controller;
        }

        public IPatientData PatientData { get; }

        public IController Controller { get; }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Controller.PatientModel.SearchTextId = searchText.Text;
        }
    }
}