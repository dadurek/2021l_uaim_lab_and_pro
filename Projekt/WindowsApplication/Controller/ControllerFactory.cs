namespace Controller
{
    using Model.IModel;
    using Model.Models;
    using Utilities;

    public static class ControllerFactory
    {
        private static IController controller;

        public static IController GetController(IEventDispatcher dispatcher)
        {
            if (controller != null)
                return controller;
            IDoctorModel doctorModel = new DoctorModel(dispatcher);

            IPatientModel patientModel = new PatientModel(dispatcher);

            IController newController = new Controller(dispatcher, doctorModel, patientModel);

            controller = newController;

            return controller;
        }
    }
}