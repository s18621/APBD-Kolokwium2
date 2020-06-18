namespace APBD_Kolokwium2.Models
{
    public class Player_Team
    {
        public int IdPlayer { get; set; }
        public int IdTeam { get; set; }
        public int NumonShirt { get; set; }
        public string Comment { get; set; }

        public Team Team { get; set; }
        public Player Player { get; set; }
    }
}