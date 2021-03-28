using System;

namespace Doctors.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Application;
    using Domain.DoctorsAggregate;
    using EntityFramework;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualBasic.CompilerServices;

    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> logger;
        private readonly IDoctorQueriesHandler DoctorQueriesHandler;
        private readonly DoctorContext doctorContext;

        public DoctorsController(ILogger<DoctorsController> logger, IDoctorQueriesHandler DoctorQueriesHandler,
            DoctorContext doctorContext)
        {
            this.logger = logger;
            this.DoctorQueriesHandler = DoctorQueriesHandler;
            this.doctorContext = doctorContext;
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

        [HttpPost("add-doctor")]
        public void AddDoctor( DoctorDto doctorDto)
        {
            Console.WriteLine(doctorDto.FirstName);
            Console.WriteLine(doctorDto.Sex);
            Console.WriteLine(doctorDto.Specializations.Count());
            DoctorQueriesHandler.Add(doctorDto);
        }
    }
}