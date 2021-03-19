namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using System.Threading.Tasks;

    public interface IExaminationRoomsSelectorHandler
    {
        Task<int> GetExaminationRoomsSelectionAsync();
    }
}
