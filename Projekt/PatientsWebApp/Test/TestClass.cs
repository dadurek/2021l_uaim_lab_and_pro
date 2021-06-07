namespace Test
{
    using System.Threading;
    using Controller;
    using FluentAssertions;
    using Model.Configuration;
    using Model.Models;
    using Moq;
    using Utilities;
    using Xunit;

    public class TestClass
    {
        // Model test

        [Fact]
        public void ModelShouldNotBeNull()
        {
            var mock1 = new Mock<IEventDispatcher>();
            var mock2 = new Mock<ServiceConfiguration>();
            var ret = new Model(mock1.Object, mock2.Object);
            ret.Should().NotBeNull();
        }

        [Fact]
        public void ModelShouldReturnAppropriateBestDoctor()
        {
            var mock1 = new Mock<IEventDispatcher>();
            var mock2 = new Mock<ServiceConfiguration>();
            var model = new Model(mock1.Object, mock2.Object);
            model.SearchTextBestDoctor = "1";
            model.LoadBestDoctor();
            Thread.Sleep(1000);
            var result = model.DoctorBest;
            result.Id.Should().BeOfType(typeof(int)).And.BePositive().And.BeGreaterThan(0).And.BeInRange(0, 2).And
                .Be(int.Parse("1"));
            result.Name.Should().NotBeNull().And.NotBeEmpty().And
                .BeOneOf("Marcin", "Maciej", "We", "Like", "writing", "unit","tests","seriously");
        }


        [Fact]
        public void ModelShouldReturnAppropriateListOfDoctors()
        {
            var mock1 = new Mock<IEventDispatcher>();
            var mock2 = new Mock<ServiceConfiguration>();
            var model = new Model(mock1.Object, mock2.Object);
            model.LoadDoctorList();
            Thread.Sleep(1000);
            var result = model.DoctorList;
            var doctorData = result.Should().HaveCount(2).And.Subject.GetEnumerator().Current;
            doctorData?.Specializations.Should().HaveCount(1);
            doctorData?.Sex.Should().Be("Male");
        }

        // Controller test
        [Fact]
        public void ControllerShouldNotBeNull()
        {
            var mock1 = new Mock<IEventDispatcher>();
            var mock2 = new Mock<ServiceConfiguration>();
            var model = new Model(mock1.Object, mock2.Object) as IModel;
            var controller = new Controller(mock1.Object, model);
            controller.Should().NotBeNull();
        }

        [Fact]
        public void ControllerShouldSetAppropriateDoctorsToModel()
        {
            var mock1 = new Mock<IEventDispatcher>();
            var mock2 = new Mock<ServiceConfiguration>();
            var model = new Model(mock1.Object, mock2.Object) as IModel;
            var controller = new Controller(mock1.Object, model);
            controller.GetAllDoctors();
            Thread.Sleep(1000);
            var result = controller.Model.DoctorList;
            var doctorData = result.Should().HaveCount(2).And.Subject.GetEnumerator().Current;
            doctorData?.Specializations.Should().HaveCount(1);
            doctorData?.Sex.Should().Be("Male");
        }
    }
}