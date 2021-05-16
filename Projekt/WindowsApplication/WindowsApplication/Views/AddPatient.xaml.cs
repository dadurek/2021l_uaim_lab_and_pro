namespace ClientUWP.Views
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Controller;
    using global::Utilities;
    using Model.Dto;
    using Utilities;

    public sealed partial class AddPatient : Page
    {
        public AddPatient()
        {
            InitializeComponent();

            var dispatcher = new EventDispatcher() as IEventDispatcher;

            Controller = ControllerFactory.GetController(dispatcher);

            DataContext = Controller;
        }

        public IController Controller { get; }

        private void Id_TextChanged(object sender, TextChangedEventArgs e)
        {
            Controller.PatientModel.NewPatient.Id = int.Parse(Id.Text);
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Controller.PatientModel.NewPatient.Name = Name.Text;
        }

        private void Pesel_TextChanged(object sender, TextChangedEventArgs e)
        {
            Controller.PatientModel.NewPatient.Pesel = Pesel.Text;
        }

        private void Type_TextChanged(object sender, TextChangedEventArgs e)
        {
            Controller.PatientModel.NewCondition.Type = int.Parse(Type.Text);
        }

        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            Controller.PatientModel.ConditionDelete = (sender as FrameworkElement).DataContext as ConditionDto;
            Controller.PatientModel.DeleteConditionFromNewConditionList();
        }
    }
}