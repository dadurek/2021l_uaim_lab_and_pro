using System.Collections.Generic;
using Doctors.Web.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Doctors.Web.Controllers
{
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> logger;
        private readonly IDoctorQueriesHandler DoctorQueriesHandler;

        public DoctorsController(ILogger<DoctorsController> logger, IDoctorQueriesHandler DoctorQueriesHandler)
        {
            this.logger = logger;
            this.DoctorQueriesHandler = DoctorQueriesHandler;
    }

        [HttpGet("doctors")]
        public IEnumerable<DoctorDto> GetAll()
        {
            return DoctorQueriesHandler.GetAll();
        }

        [HttpGet("doctor")]
        public IEnumerable<DoctorDto> GetBySpecialization([FromQuery] int specialization)
        {
            return DoctorQueriesHandler.GetBySpecialization(specialization);
        }
    }
}
