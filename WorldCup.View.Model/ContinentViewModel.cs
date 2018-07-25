using System.ComponentModel.DataAnnotations;

namespace WorldCup.View.Model
{
    public class ContinentViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Continent Name")]
        public string Name { get; set; }
    }
}
