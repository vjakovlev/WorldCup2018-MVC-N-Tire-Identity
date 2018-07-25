using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data.Model;

namespace WorldCup.Interfaces
{
    public interface IPlayerRepository
    {
        //add
        void AddPlayer(Player player);

        //getAll
        List<Player> GetAllPlayers();
        List<Player> GetAllPlayers(string searchByPlayer, string searchPlayer);

        //find
        Player FindPlayer(int id);

        //edit
        void EditPlayer(Player player);

        //remove
        void RemovePlayer(int id);
    }
}
