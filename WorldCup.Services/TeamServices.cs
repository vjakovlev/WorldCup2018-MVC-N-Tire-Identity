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
    public class TeamServices
    {
        //create
        public void CreateTeam(TeamViewModel team)
        {
            using (var repository = new TeamRepository())
            {
                var teamDbModel = new Team
                {
                    Id = team.Id,
                    Name = team.Name,
                    Coatch = team.Coatch,
                    ShortDescription = team.ShortDescription,
                    PhotoUrl = team.PhotoUrl,
                    PhotoAlt = team.PhotoAlt,
                    ContinentId = team.ViewContinentId
                };

                repository.AddTeam(teamDbModel);
            }
        }

        //Return All
        public List<TeamViewModel> ReturnAllTeams()
        {
            using (var repository = new TeamRepository())
            {
                return repository.GetAllTeams().Select(x => x.ToModel()).ToList();
            }
        }

        public List<TeamViewModel> ReturnAllTeams(string searchByTeam, string searchTeam)
        {
            using (var repository = new TeamRepository())
            {
                return repository.GetAllTeams(searchByTeam, searchTeam).Select(x => x.ToModel()).ToList();
            }
        }


        //Return
        public TeamViewModel ReturnTeam(int Id)
        {
            using (var repository = new TeamRepository())
            {
                return repository.FindTeam(Id)?.ToModel();
            }
        }

        //Update
        public void UpdateTeam(TeamViewModel team)
        {
            using (var repository = new TeamRepository())
            {
                var teamDbModel = new Team
                {
                    Id = team.Id,
                    Name = team.Name,
                    Coatch = team.Coatch,
                    ShortDescription = team.ShortDescription,
                    PhotoUrl = team.PhotoUrl,
                    PhotoAlt = team.PhotoAlt,
                    ContinentId = team.ViewContinentId
                };

                repository.EditTeam(teamDbModel);
            }
        }

        //Delete
        public void DeleteTeam(int Id)
        {
            using (var repository = new TeamRepository())
            {
                repository.RemoveTeam(Id);
            }
        }
    }
}
