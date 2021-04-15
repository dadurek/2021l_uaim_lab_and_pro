namespace ExaminationRoomsSelector.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Dtos;
    using Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    public class ExaminationRoomsSelectorController : ControllerBase
    {
        private readonly ILogger<ExaminationRoomsSelectorController> logger;
        private readonly IExaminationRoomsSelectorHandler examinationRoomsSelectorHandler;

        public ExaminationRoomsSelectorController(ILogger<ExaminationRoomsSelectorController> logger,
            IExaminationRoomsSelectorHandler examinationRoomsSelectorHandler)
        {
            this.logger = logger;
            this.examinationRoomsSelectorHandler = examinationRoomsSelectorHandler;
        }

        [HttpGet("examination-rooms-selection")]
        public async Task<List<DoctorRoomDto>> GetLaboratoryDiagnosticiansDetails()
        {
            return await examinationRoomsSelectorHandler.GetExaminationRoomsSelectionAsync();
        }

        [HttpPost("add-doctor")]
        public async void AddDoctor(DoctorDto doctorDto)
        {
            examinationRoomsSelectorHandler.AddDoctor(doctorDto);
        }

        [HttpPost("add-room")]
        public async void AddRoom(ExaminationRoomDto examinationRoomDto)
        {
            examinationRoomsSelectorHandler.AddRoom(examinationRoomDto);
        }
    }
}