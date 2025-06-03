using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingAppPractice.Models
{
    public class Gamer_Game
    {
        [Key]
        public int GGKey { get; set; }

        public int UserID { get; set; }

        public Gamer? Gamer { get; set; }

        public int GameID { get; set; }

        public Game? Game { get; set; }

    }
}
