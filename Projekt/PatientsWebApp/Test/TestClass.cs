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
            ret.Model.Should().NotBeNull();
            ret.Model.Should().NotBeNull();
        }

        [Fact]
        public void DoctorShouldNotBeNull()
        {
            var mock = new Mock<IEventDispatcher>();
            var ret = new Model(mock.Object);
            ret.Should().NotBeNull();
        }

        [Fact]
        public void PatientShouldNotBeNull()
        {
            var mock = new Mock<IEventDispatcher>();
            var ret = new Model(mock.Object);
            ret.Should().NotBeNull();
        }

        [Fact]
        public void ShouldReturnSpecifiedPatientById()
        {
            var mock = new Mock<IEventDispatcher>();
            var controller = ControllerFactory.GetController(mock.Object);
            controller.Model.SearchTextPatientId = "1";
            controller.GetPatientId();
            Thread.Sleep(1000);
            controller.Model.PatientId.Id.Should().Be(int.Parse(controller.Model.SearchTextPatientId));
        }
    }
}