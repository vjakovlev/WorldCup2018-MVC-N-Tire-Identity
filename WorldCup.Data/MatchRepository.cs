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
    public class MatchRepository : IMatchRepository, IDisposable
    {
        private readonly WorldCupDbContext context;

        public MatchRepository()
        {
            context = new WorldCupDbContext();
        }

        //add
        public void AddMatch(Match match)
        {
            context.Matches.Add(match);
            context.SaveChanges();
        }

        //getAll
        public List<Match> GetAllMatches()
        {
            return context.Matches.Include(x => x.TeamA).Include(x => x.TeamB).ToList();
        }

        public List<Match> GetAllMatches(string searchByMatch, string searchMatch)
        {
            if (searchMatch != null)
            {
                if (searchByMatch == "TeamA")
                {
                    return context.Matches.Include(x => x.TeamA).Include(x => x.TeamB).Where(x => x.TeamA.Name.Contains(searchMatch)).ToList();
                }
                else
                {
                    return context.Matches.Include(x => x.TeamA).Include(x => x.TeamB).Where(x => x.TeamB.Name.Contains(searchMatch)).ToList();
                }
            }
            else
            {
                return context.Matches.Include(x => x.TeamA).Include(x => x.TeamB).ToList();
            }
        }

        //find
        public Match FindMatch(int id)
        {
            return context.Matches.Include(x => x.TeamA).Include(x => x.TeamB).FirstOrDefault(match => match.Id == id);
        }

        //edit
        public void EditMatch(Match match)
        {
            context.Matches.AddOrUpdate(match);
            context.SaveChanges();
        }

        //remove
        public void RemoveMatch(int id)
        {
            var match = context.Matches.Find(id);
            context.Matches.Remove(match ?? throw new InvalidOperationException());
            context.SaveChanges();
        }

        //dispose
        public void Dispose()
        {
            context.Dispose();
            SqlConnection.ClearAllPools();
        }
    }
}
