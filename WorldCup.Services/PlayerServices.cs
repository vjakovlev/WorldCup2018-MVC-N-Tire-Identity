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
    public class PlayerServices
    {
        //create
        public void CreatePlayer(PlayerViewModel player)
        {
            using (var repository = new PlayerRepository())
            {
                var playerDbModel = new Player
                {
                    Id = player.Id,
                    Name = player.Name,
                    Age = player.Age,
                    TeamId = player.ViewTeamId,
                    PositionId = player.ViewPositionId
                };

                repository.AddPlayer(playerDbModel);
            }
        }

        //Return All
        public List<PlayerViewModel> ReturnAllPlayers()
        {
            using (var repository = new PlayerRepository())
            {
                return repository.GetAllPlayers().Select(x => x.ToModel()).ToList();
            }
        }

        public List<PlayerViewModel> ReturnAllPlayers(string searchByPlayer, string searchPlayer)
        {
            using (var repository = new PlayerRepository())
            {
                return repository.GetAllPlayers(searchByPlayer, searchPlayer).Select(x => x.ToModel()).ToList();
            }
        }

        //Return
        public PlayerViewModel ReturnPlayer(int Id)
        {
            using (var repository = new PlayerRepository())
            {
                return repository.FindPlayer(Id)?.ToModel();
            }
        }

        //Update
        public void UpdatePlayer(PlayerViewModel player)
        {
            using (var repository = new PlayerRepository())
            {
                var playerDbModel = new Player
                {
                    Id = player.Id,
                    Name = player.Name,
                    Age = player.Age,
                    TeamId = player.ViewTeamId,
                    PositionId = player.ViewPositionId
                };

                repository.EditPlayer(playerDbModel);
            }
        }

        //Delete
        public void DeletePlayer(int Id)
        {
            using (var repository = new PlayerRepository())
            {
                repository.RemovePlayer(Id);
            }
        }

    }
}
