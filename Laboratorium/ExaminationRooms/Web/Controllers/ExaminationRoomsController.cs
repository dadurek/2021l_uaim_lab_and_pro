namespace ExaminationRooms.Web.Controllers
{
    using System.Collections.Generic;
    using Application;
    using EntityFramework;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    public class ExaminationRoomsController : ControllerBase
    {
        private readonly ILogger<ExaminationRoomsController> logger;
        private readonly IExaminationRoomQueriesHandler examinationRoomQueriesHandler;
        private readonly ExaminationRoomContext examinationRoomContext;

        public ExaminationRoomsController(ILogger<ExaminationRoomsController> logger,
            IExaminationRoomQueriesHandler examinationRoomQueriesHandler, ExaminationRoomContext examinationRoomContext)
        {
            this.logger = logger;
            this.examinationRoomQueriesHandler = examinationRoomQueriesHandler;
            this.examinationRoomContext = examinationRoomContext;
        }

        [HttpGet("examination-rooms")]
        public IEnumerable<ExaminationRoomDto> GetAll()
        {
            DbInit.Initialize(examinationRoomContext);
            return examinationRoomQueriesHandler.GetAll();
        }

        [HttpGet("examination-room")]
        public IEnumerable<ExaminationRoomDto> GetBySpecialization([FromQuery] int certificationType)
        {
            return examinationRoomQueriesHandler.GetByCertificationType(certificationType);
        }
    }
}