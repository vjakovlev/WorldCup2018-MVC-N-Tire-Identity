using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCup.Data.Model
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int? TeamAScore { get; set; }
        public int? TeamBScore { get; set; }

        public int TeamAId { get; set; }
        [ForeignKey("TeamAId")]
        public Team TeamA { get; set; }

        public int TeamBId { get; set; }
        [ForeignKey("TeamBId")]
        public Team TeamB { get; set; }
    }
}