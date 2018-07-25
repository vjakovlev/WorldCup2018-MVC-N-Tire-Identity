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
    public class ContinentServices
    {
        //Return All
        public List<ContinentViewModel> ReturnAllContinents(string searchCriteria = null)
        {
            using (var repository = new ContinentRepository())
            {
                return repository.GetAllContinents(searchCriteria).Select(x => x.ToModel()).ToList();
            }
        }

        //Return
        public ContinentViewModel ReturnContinent(int Id)
        {
            using (var repository = new ContinentRepository())
            {
                return repository.FindContinent(Id)?.ToModel();
            }
        }

        //Create
        public void CreateContinent(ContinentViewModel continent)
        {
            using (var repository = new ContinentRepository())
            {
                var ContinentDbModel = new Continent
                {
                    Id = continent.Id,
                    Name = continent.Name
                };

                repository.AddContinent(ContinentDbModel);
            }
        }

        //Delete
        public void DeleteContinent(int Id)
        {
            using (var repository = new ContinentRepository())
            {
                repository.RemoveContinent(Id);
            }
        }

        //Update
        public void UpdateContinent(ContinentViewModel continent)
        {
            using (var repository = new ContinentRepository())
            {
                var continentDbModel = new Continent
                {
                    Id = continent.Id,
                    Name = continent.Name
                };

                repository.EditContinent(continentDbModel);
            }
        }
    }
}
