using System.Data.Entity;
using WorldCup.Data;

namespace WorldCup.Models
{
    public static class IdentityDataInitializer
    {
        public static void InitDbIdentity()
        {
            Database.SetInitializer(new IdentityDbInitializer());
        }
    }
}