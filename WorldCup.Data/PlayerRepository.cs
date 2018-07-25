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
    public class PlayerRepository : IPlayerRepository, IDisposable
    {
        private readonly WorldCupDbContext context;

        public PlayerRepository()
        {
            context = new WorldCupDbContext();
        }

        //add
        public void AddPlayer(Player player)
        {
            context.Players.Add(player);
            context.SaveChanges();
        }

        //getAll
        public List<Player> GetAllPlayers()
        {
            return context.Players.Include(x => x.Team).Include(x => x.Position).ToList();
        }

        public List<Player> GetAllPlayers(string searchByPlayer, string searchPlayer)
        {
            if (searchPlayer != null)
            {
                if (searchByPlayer == "Name")
                {
                    return context.Players.Include(x => x.Team).Include(x => x.Position).Where(x => x.Name.Contains(searchPlayer)).ToList();
                }
                else if (searchByPlayer == "Age")
                {
                    return context.Players.Include(x => x.Team).Include(x => x.Position).Where(x => x.Age.ToString() == searchPlayer).ToList();
                }
                else if (searchByPlayer == "Team")
                {
                    return context.Players.Include(x => x.Team).Include(x => x.Position).Where(x => x.Team.Name.Contains(searchPlayer)).ToList();
                }
                else
                {
                    return context.Players.Include(x => x.Team).Include(x => x.Position).Where(x => x.Position.Name.Contains(searchPlayer)).ToList();
                }
            }
            else
            {
                return context.Players.Include(x => x.Team).Include(x => x.Position).ToList();
            }
        }

        //find
        public Player FindPlayer(int id)
        {
            return context.Players.Include(x => x.Team).Include(x => x.Position).FirstOrDefault(player => player.Id == id);
        }

        //edit
        public void EditPlayer(Player player)
        {
            context.Players.AddOrUpdate(player);
            context.SaveChanges();
        }

        //remove
        public void RemovePlayer(int id)
        {
            var player = context.Players.Find(id);
            context.Players.Remove(player ?? throw new InvalidOperationException());
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
