using System.Data.Entity;

namespace WorldCup.Data
{
    public static class WorldCupDataInitializer
    {
        public static void InitDb()
        {
            Database.SetInitializer(new WorldCupDbInitializer());
        }
    }
}
