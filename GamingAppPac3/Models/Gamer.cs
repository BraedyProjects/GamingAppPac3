using System.ComponentModel.DataAnnotations;

namespace GamingAppPractice.Models
{
    public class Gamer
    {
        [Key]public int UserID { get; set; }


        public string? Name{ get; set; }

        public string? Surname { get; set; }

        public string? Location { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string? InGameName { get; set; }

        public ICollection<Gamer_Game> Gamer_Gamers { get; set; } = new List<Gamer_Game>();


    }
}
