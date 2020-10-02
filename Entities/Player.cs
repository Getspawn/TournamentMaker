using System.ComponentModel.DataAnnotations;

namespace TournamentMaker.Entities
{
    public class Player
    {
        [Key]
        public string PlayerId { get; set; }

        public string Name { get; set; }

        public char Category { get; set; }
    }
}
