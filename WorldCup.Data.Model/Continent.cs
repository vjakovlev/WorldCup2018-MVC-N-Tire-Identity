using System.Collections.Generic;

namespace WorldCup.Data.Model
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
}
