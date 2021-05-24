// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Model.Views
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using ClientUWP.Utilities;
    using ClientUWP.Views;
    using Controller;
    using IData;
    using Utilities;

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            var dispatcher = new EventDispatcher() as IEventDispatcher;

            Controller = ControllerFactory.GetController(dispatcher);
            DoctorData = Controller.DoctorModel;
            DataContext = Controller;
        }

        public IDoctorData DoctorData { get; }

        public IController Controller { get; }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Home));
        }

        private void NavigationView_SelectionChanged(NavigationView sender,
            NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                // code for the settigns page
            }
            else
            {
                var item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "Home":
                        ContentFrame.Navigate(typeof(Home));
                        break;
                    case "Doctors":
                        Controller.DoctorModel.LoadDoctorList();
                        ContentFrame.Navigate(typeof(Doctors));
                        break;
                    case "PatientId":
                        ContentFrame.Navigate(typeof(PatientId));
                        break;
                    case "PatientPesel":
                        ContentFrame.Navigate(typeof(PatientPesel));
                        break;
                    case "BestDoctor":
                        ContentFrame.Navigate(typeof(BestDoctor));
                        break;
                    case "AddPatient":
                        ContentFrame.Navigate(typeof(AddPatient));
                        break;
                    case "DeletePatientId":
                        ContentFrame.Navigate(typeof(DeletePatientId));
                        break;
                    case "DeletePatientPesel":
                        ContentFrame.Navigate(typeof(DeletePatientPesel));
                        break;
                }
            }
        }
    }
}