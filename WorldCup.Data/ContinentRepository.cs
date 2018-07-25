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
    public class ContinentRepository : IContinentRepository, IDisposable
    {
        private readonly WorldCupDbContext context;

        public ContinentRepository()
        {
            context = new WorldCupDbContext();
        }

        // getAll
        public List<Continent> GetAllContinents(string searchCriteria)
        {
            return string.IsNullOrEmpty(searchCriteria) ? context.Continents.ToList() : context.Continents.Where(continent => continent.Name.Contains(searchCriteria)).ToList();
        }

        //find
        public Continent FindContinent(int id)
        {
            return context.Continents.FirstOrDefault(continenet => continenet.Id == id);
        }

        //add
        public void AddContinent(Continent continent)
        {
            context.Continents.Add(continent);
            context.SaveChanges();
        }

        //remove
        public void RemoveContinent(int id)
        {
            var continent = context.Continents.Find(id);
            context.Continents.Remove(continent ?? throw new InvalidOperationException());
            context.SaveChanges();
        }

        //edit
        public void EditContinent(Continent continent)
        {
            context.Continents.AddOrUpdate(continent);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            SqlConnection.ClearAllPools();
        }
    }
}