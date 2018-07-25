using WorldCup.Data;

namespace WorldCup.Services
{
    public static class WorldCupDatabaseInitializer
    {
        public static void InitDb()
        {
            WorldCupDataInitializer.InitDb();
        }
    }
}
