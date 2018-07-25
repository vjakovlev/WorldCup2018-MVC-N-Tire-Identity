using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCup.View.Model
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Player Name")]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [NotMapped]
        [Display(Name = "Team")]
        public int ViewTeamId { get; set; }
        public TeamViewModel Team { get; set; }

        [NotMapped]
        [Display(Name = "Position")]
        public int ViewPositionId { get; set; }
        public PositionViewModel Position { get; set; }
    }
}
