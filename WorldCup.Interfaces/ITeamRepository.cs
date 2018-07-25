using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data.Model;

namespace WorldCup.Interfaces
{
    public interface ITeamRepository
    {
        //add team
        void AddTeam(Team team);

        //getAll
        List<Team> GetAllTeams();
        List<Team> GetAllTeams(string searchByTeam, string searchTeam);

        //find
        Team FindTeam(int id);

        //edit
        void EditTeam(Team team);

        //remove
        void RemoveTeam(int id);
    }
}
