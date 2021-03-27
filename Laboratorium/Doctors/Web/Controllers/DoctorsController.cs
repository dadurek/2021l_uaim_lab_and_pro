namespace Doctors.Web.Controllers
{
    using System.Collections.Generic;
    using Application;
    using EntityFramework;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> logger;
        private readonly IDoctorQueriesHandler DoctorQueriesHandler;
        private readonly DoctorContext _doctorContext;

        public DoctorsController(ILogger<DoctorsController> logger, IDoctorQueriesHandler DoctorQueriesHandler,
            DoctorContext doctorContext)
        {
            this.logger = logger;
            this.DoctorQueriesHandler = DoctorQueriesHandler;
            this._doctorContext = doctorContext;
        }

        [HttpGet("doctors")]
        public IEnumerable<DoctorDto> GetAll()
        {
            return DoctorQueriesHandler.GetAll(_doctorContext);
        }

        [HttpGet("doctor")]
        public IEnumerable<DoctorDto> GetBySpecialization([FromQuery] int specialization)
        {
            return DoctorQueriesHandler.GetBySpecialization(specialization);
        }
    }
}