namespace ExaminationRoomsSelector.Web.Controllers
{
    using System.Threading.Tasks;
    using ExaminationRoomsSelector.Web.Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    
    [ApiController]
    public class ExaminationRoomsSelectorController : ControllerBase
    {
        private readonly ILogger<ExaminationRoomsSelectorController> logger;
        private readonly IExaminationRoomsSelectorHandler examinationRoomsSelectorHandler;

        public ExaminationRoomsSelectorController(ILogger<ExaminationRoomsSelectorController> logger, IExaminationRoomsSelectorHandler examinationRoomsSelectorHandler)
        {
            this.logger = logger;
            this.examinationRoomsSelectorHandler = examinationRoomsSelectorHandler;
        }

        [HttpGet("examination-rooms-selection")]
        public async Task<int> GetLaboratoryDiagnosticiansDetails()
        {
            return await examinationRoomsSelectorHandler.GetExaminationRoomsSelectionAsync();
        }
    }
}
