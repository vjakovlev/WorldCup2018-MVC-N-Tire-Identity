using WorldCup.View.Model;
using WorldCup.Data.Model;

namespace WorldCup.Mapper
{
    public static class MatchMapper
    {
        public static MatchViewModel ToModel(this Match match)
        {
            return new MatchViewModel
            {
                Id = match.Id,
                Date = match.Date,
                Time = match.Time,
                TeamAScore = match.TeamAScore,
                TeamBScore = match.TeamBScore,
                TeamA = match.TeamA?.ToModel(),
                TeamB = match.TeamB?.ToModel()
            };
        }
    }
}
