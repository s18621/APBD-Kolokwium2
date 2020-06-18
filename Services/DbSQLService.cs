using APBD_Kolokwium2.DTO;
using APBD_Kolokwium2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Kolokwium2.Services
{
    public interface DbSQLService
    {
        public Championship_Team GetTeam(int ID);
        public IActionResult putPlayer(Request req, int ID);
    }
}
