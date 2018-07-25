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
    public class TeamRepository : ITeamRepository, IDisposable
    {
        private readonly WorldCupDbContext context;

        public TeamRepository()
        {
            context = new WorldCupDbContext();
        }

        //add team
        public void AddTeam(Team team)
        {
            context.Teams.Add(team);
            context.SaveChanges();
        }

        //getAll
        public List<Team> GetAllTeams()
        {
            return context.Teams.Include(x => x.Continent).ToList();
        }

        public List<Team> GetAllTeams(string searchByTeam, string searchTeam)
        {

            if (searchTeam != null)
            {
                if (searchByTeam == "Name")
                {
                    return context.Teams.Include(x => x.Continent).Where(x => x.Name.Contains(searchTeam)).ToList();
                }
                else
                {
                    return context.Teams.Include(x => x.Continent).Where(x => x.Continent.Name.Contains(searchTeam)).ToList();
                }
            }
            else
            {
                return context.Teams.Include(x => x.Continent).ToList();
            }
        }

        //find
        public Team FindTeam(int id)
        {
            return context.Teams.Include(x => x.Continent).FirstOrDefault(team => team.Id == id);
        }

        //edit
        public void EditTeam(Team team)
        {
            context.Teams.AddOrUpdate(team);
            //context.Entry(team).State = EntityState.Modified;
            context.SaveChanges();
        }

        //remove
        public void RemoveTeam(int id)
        {
            var team = context.Teams.Find(id);
            context.Teams.Remove(team ?? throw new InvalidOperationException());
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
