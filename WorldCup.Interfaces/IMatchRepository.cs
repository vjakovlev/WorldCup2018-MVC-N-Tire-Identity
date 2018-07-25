using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data.Model;

namespace WorldCup.Interfaces
{
    public interface IMatchRepository
    {
        //add
        void AddMatch(Match match);

        //getAll
        List<Match> GetAllMatches();
        List<Match> GetAllMatches(string searchByMatch, string searchMatch);

        //find
        Match FindMatch(int id);

        //edit
        void EditMatch(Match match);

        //remove
        void RemoveMatch(int id);
    }
}
