namespace Test
{
    using System.Threading;
    using Controller;
    using FluentAssertions;
    using Model.Models;
    using Moq;
    using Utilities;
    using Xunit;

    public class TestClass
    {
        [Fact]
        public void ControllerShouldNotBeNull()
        {
            var mock = new Mock<IEventDispatcher>();
            var ret = ControllerFactory.GetController(mock.Object);
            ret.Should().NotBeNull();
            ret.DoctorModel.Should().NotBeNull();
            ret.PatientModel.Should().NotBeNull();
        }

        [Fact]
        public void DoctorShouldNotBeNull()
        {
            var mock = new Mock<IEventDispatcher>();
            var ret = new DoctorModel(mock.Object);
            ret.Should().NotBeNull();
        }

        [Fact]
        public void PatientShouldNotBeNull()
        {
            var mock = new Mock<IEventDispatcher>();
            var ret = new PatientModel(mock.Object);
            ret.Should().NotBeNull();
        }

        [Fact]
        public void ShouldReturnSpecifiedPatientById()
        {
            var mock = new Mock<IEventDispatcher>();
            var controller = ControllerFactory.GetController(mock.Object);
            controller.PatientModel.SearchTextId = "1";
            controller.ShowPatientIdCommand.Execute(null);
            Thread.Sleep(1000);
            controller.PatientModel.PatientId.Id.Should().Be(int.Parse(controller.PatientModel.SearchTextId));
        }
    }
}