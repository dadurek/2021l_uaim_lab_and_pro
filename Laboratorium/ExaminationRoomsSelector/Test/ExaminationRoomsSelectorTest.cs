namespace Test
{
    using System;
    using ExaminationRoomsSelector.Web.Application.Queries;
    using Xunit;

    public class ExaminationRoomsSelectorTest
    {
        [Fact]
        public void Test1()
        {
            var selector = new ExaminationRoomsSelectorQueryHandler(null, null);

            Action action = () => selector.GetExaminationRoomsSelectionAsync();
            
        }
    }
}