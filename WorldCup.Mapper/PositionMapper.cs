using WorldCup.View.Model;
using WorldCup.Data.Model;

namespace WorldCup.Mapper
{
    public static class PositionMapper
    {
        public static PositionViewModel ToModel(this Position position)
        {
            return new PositionViewModel
            {
                Id = position.Id,
                Name = position.Name
            };
        }
    }
}
