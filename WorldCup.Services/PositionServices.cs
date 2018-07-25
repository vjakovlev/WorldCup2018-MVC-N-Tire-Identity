using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data.Model;
using WorldCup.View.Model;
using WorldCup.Mapper;
using WorldCup.Data;

namespace WorldCup.Services
{
    public class PositionServices
    {

        //Return All
        public List<PositionViewModel> ReturnAllPositions(string searchCriteria = null)
        {
            using (var repository = new PositionRepository())
            {
                return repository.GetAllPositions(searchCriteria).Select(x => x.ToModel()).ToList();
            }
        }

        //Return
        public PositionViewModel ReturnPosition(int Id)
        {
            using (var repository = new PositionRepository())
            {
                return repository.FindPosition(Id)?.ToModel();
            }
        }
    }
}
