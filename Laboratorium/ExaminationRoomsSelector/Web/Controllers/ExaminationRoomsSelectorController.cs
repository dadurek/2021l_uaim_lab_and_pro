using System;
using System.Collections.Generic;
using ExaminationRoomsSelector.Web.Application.Dtos;

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
        public async Task<List<DoctorRoomDto>> GetLaboratoryDiagnosticiansDetails()
        {
            return await examinationRoomsSelectorHandler.GetExaminationRoomsSelectionAsync();
        }

        [HttpPost("add-doctor")]
        public async void AddDoctor( DoctorDto doctorDto)
        {
            examinationRoomsSelectorHandler.Add(doctorDto);
        }
    }
}
