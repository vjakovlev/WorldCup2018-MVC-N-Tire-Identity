using WorldCup.View.Model;
using WorldCup.Data.Model;

namespace WorldCup.Mapper
{
    public static class PlayerMapper
    {
        public static PlayerViewModel ToModel(this Player player)
        {
            return new PlayerViewModel
            {
                Id = player.Id,
                Name = player.Name,
                Age = player.Age,
                Team = player.Team?.ToModel(),
                Position = player.Position?.ToModel()
            };
        }
    }
}
