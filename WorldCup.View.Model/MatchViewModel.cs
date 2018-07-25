using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCup.View.Model
{
    public class MatchViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Match Date")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Match Time")]
        public DateTime Time { get; set; }

        [Display(Name = "Home Team Score")]
        public int? TeamAScore { get; set; }

        [Display(Name = "Away Team Score")]
        public int? TeamBScore { get; set; }

        public int ViewTeamAId { get; set; }

        [ForeignKey("ViewTeamAId")]
        public virtual TeamViewModel TeamA { get; set; }

        public int ViewTeamBId { get; set; }

        [ForeignKey("ViewTeamBId")]
        public virtual TeamViewModel TeamB { get; set; }
    }
}
