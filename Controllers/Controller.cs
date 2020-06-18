using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_Kolokwium2.DTO;
using APBD_Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APBD_Kolokwium2.Controllers
{
    [ApiController]
    [Route("/api")]
    public class Controller : ControllerBase
    {

        private readonly DbSQLService _service;

        public Controller(DbSQLService service)
        {
            _service = service;
        }

        [HttpGet("/championships/{ID}")]
       
        public IActionResult GetTeam(int ID)
        {
            return Ok(_service.GetTeam(ID));
        }
        [HttpPost("/teams/{ID}/players")]
        public void PostPlayer(Request req, int ID)
        {
            _service.putPlayer(req, ID);
        }
    }
}
