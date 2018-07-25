using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data.Model;

namespace WorldCup.Interfaces
{
    public interface IPositionRepository
    {
        // getAll
        List<Position> GetAllPositions(string searchCriteria);

        //find
        Position FindPosition(int id);
    }
}
