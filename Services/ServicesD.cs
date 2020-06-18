using APBD_Kolokwium2.DTO;
using APBD_Kolokwium2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Kolokwium2.Services
{
    public class ServicesD : DbSQLService
    {
        private readonly s18621Context _context;
        public ServicesD(s18621Context context)
        {
            _context = context;
        }

        public Championship_Team GetTeam(int ID)
        {
            var teams = _context.championship_Teams.Include(m => m.Championship).Include(p => p.Team).SingleOrDefault(m => m.IdChampionship == ID);

            return teams;
        }
        public IActionResult putPlayer(Request req, int ID)
        {
            Player player = new Player
            {
                IdPlayer = req.IdPlayer,
                FirstName = req.FirstName,
                LastName = req.LastName,
                DateOfBirth = req.BirthDate
            };
            Player_Team pt = new Player_Team
            {
                IdPlayer = req.IdPlayer,
                IdTeam = ID,
                NumonShirt = req.Numonshirt,
                Comment = req.Comment
            };
            if (!_context.Players.Any(s => s.LastName.Equals(req.LastName))) _context.Players.Add(player);

            _context.Player_Teams.Add(pt);

            _context.SaveChanges();
            

            return new OkObjectResult(player);
        }
    }
}
