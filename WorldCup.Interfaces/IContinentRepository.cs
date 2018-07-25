using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data.Model;

namespace WorldCup.Interfaces
{
    public interface IContinentRepository
    {
        // getAll
        List<Continent> GetAllContinents(string searchCriteria);

        //find
        Continent FindContinent(int id);

        //add
        void AddContinent(Continent continent);

        //remove
        void RemoveContinent(int id);

        //edit
        void EditContinent(Continent continent);
    }
}
