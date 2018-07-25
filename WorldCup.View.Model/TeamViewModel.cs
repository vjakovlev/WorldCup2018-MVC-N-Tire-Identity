using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCup.View.Model
{
    public class TeamViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Team Coatch")]
        public string Coatch { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        public string PhotoUrl { get; set; }

        [Required]
        public string PhotoAlt { get; set; }

        [NotMapped]
        public int ViewContinentId { get; set; }
        public ContinentViewModel Continent { get; set; }
    }
}
