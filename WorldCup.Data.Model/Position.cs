using System.Collections.Generic;

namespace WorldCup.Data.Model
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Player> Players { get; set; }
    }
}
