using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;
using WorldCup.Data.Model;
using System.Data.Entity.Migrations;
using WorldCup.Interfaces;

namespace WorldCup.Data
{
    public class PositionRepository : IPositionRepository, IDisposable
    {
        private readonly WorldCupDbContext context;

        public PositionRepository()
        {
            context = new WorldCupDbContext();
        }

        // getAll
        public List<Position> GetAllPositions(string searchCriteria)
        {
            return string.IsNullOrEmpty(searchCriteria) ? context.Positions.ToList() : context.Positions.Where(position => position.Name.Contains(searchCriteria)).ToList();
        }

        //find
        public Position FindPosition(int id)
        {
            return context.Positions.FirstOrDefault(position => position.Id == id);
        }

        public void Dispose()
        {
            context.Dispose();
            SqlConnection.ClearAllPools();
        }
    }
}
