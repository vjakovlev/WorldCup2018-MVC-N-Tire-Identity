using System.ComponentModel.DataAnnotations;

namespace WorldCup.View.Model
{
    public class PositionViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Player Position")]
        public string Name { get; set; }
    }
}
