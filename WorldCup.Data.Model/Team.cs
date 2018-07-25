using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCup.Data.Model
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coatch { get; set; }
        public string ShortDescription { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoAlt { get; set; }

        public int ContinentId { get; set; }
        [ForeignKey("ContinentId")]
        public Continent Continent { get; set; }

        public List<Player> Players { get; set; }
    }
}
