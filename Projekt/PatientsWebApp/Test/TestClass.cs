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

        [Fact]
        public void DoctorShouldNotBeNull()
        {
            var mock1 = new Mock<IEventDispatcher>();
            var mock2 = new Mock<ServiceConfiguration>();
            var ret = new Model(mock1.Object,mock2.Object);
            ret.Should().NotBeNull();
        }
    }
}