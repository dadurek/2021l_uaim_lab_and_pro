namespace Controller
{
    using Model.Models;
    using Utilities;

    public static class ControllerFactory
    {
        private static IController controller;

        public static IController GetController(IEventDispatcher dispatcher)
        {
            if (controller != null)
                return controller;
            IModel model = new Model(dispatcher);

            IController newController = new Controller(dispatcher, model);

            controller = newController;

            return controller;
        }
    }
}