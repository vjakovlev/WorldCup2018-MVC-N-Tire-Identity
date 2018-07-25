using WorldCup.View.Model;
using WorldCup.Data.Model;

namespace WorldCup.Mapper
{
    public static class ContinentMapper
    {
        public static ContinentViewModel ToModel(this Continent continent)
        {
            return new ContinentViewModel
            {
                Id = continent.Id,
                Name = continent.Name
            };
        }
    }
}
