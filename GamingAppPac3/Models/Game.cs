using System.ComponentModel.DataAnnotations;

namespace GamingAppPractice.Models
{
    public class Game
    {
        [Key]public int GameID { get; set; }
        public string? GameName { get; set; }

        public string? Genere { get; set; }
        public string? Description { get; set; }

        public ICollection<Gamer_Game> Gamer_Games { get; set; } = new List<Gamer_Game>();

    }
}
