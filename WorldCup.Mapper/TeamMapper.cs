using WorldCup.View.Model;
using WorldCup.Data.Model;

namespace WorldCup.Mapper
{
    public static class TeamMapper
    {
        public static TeamViewModel ToModel(this Team team)
        {
            return new TeamViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Coatch = team.Coatch,
                ShortDescription = team.ShortDescription,
                PhotoUrl = team.PhotoUrl,
                PhotoAlt = team.PhotoAlt,
                Continent = team.Continent?.ToModel()
            };
        }
    }
}
