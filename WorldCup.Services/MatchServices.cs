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
    public class MatchServices
    {
        //create
        public void CreateMatch(MatchViewModel match)
        {
            using (var repository = new MatchRepository())
            {
                var matchDbModel = new Match
                {
                    Id = match.Id,
                    Date = match.Date,
                    Time = match.Time,
                    TeamAScore = match.TeamAScore,
                    TeamBScore = match.TeamBScore,
                    TeamAId = match.ViewTeamAId,
                    TeamBId = match.ViewTeamBId

                };

                repository.AddMatch(matchDbModel);
            }
        }

        //Return All
        public List<MatchViewModel> ReturnAllMatches()
        {
            using (var repository = new MatchRepository())
            {
                return repository.GetAllMatches().Select(x => x.ToModel()).ToList();
            }
        }

        public List<MatchViewModel> ReturnAllMatches(string searchByMatch, string searchMatch)
        {
            using (var repository = new MatchRepository())
            {
                return repository.GetAllMatches(searchByMatch, searchMatch).Select(x => x.ToModel()).ToList();
            }
        }

        //Return
        public MatchViewModel ReturnMatch(int Id)
        {
            using (var repository = new MatchRepository())
            {
                return repository.FindMatch(Id)?.ToModel();
            }
        }

        //Update
        public void UpdateMatch(MatchViewModel match)
        {
            using (var repository = new MatchRepository())
            {
                var matchDbModel = new Match
                {
                    Id = match.Id,
                    Date = match.Date,
                    Time = match.Time,
                    TeamAScore = match.TeamAScore,
                    TeamBScore = match.TeamBScore,
                    TeamAId = match.ViewTeamAId,
                    TeamBId = match.ViewTeamBId
                };

                repository.EditMatch(matchDbModel);
            }
        }

        //Delete
        public void DeleteMatch(int Id)
        {
            using (var repository = new MatchRepository())
            {
                repository.RemoveMatch(Id);
            }
        }

        //Statistics
        public int TotalGoalsForTeamA()
        {
            using (var repository = new MatchRepository())
            {
                var goals = repository.GetAllMatches().ToList();

                List<int?> goloviA = new List<int?>();

                foreach (var item in goals)
                {
                    goloviA.Add(item.TeamAScore);
                };

                int?[] goalArrayA = goloviA.ToArray();

                int? totalA = 0;

                for (int i = 0; i < goalArrayA.Length; i++)
                {
                    if (goalArrayA[i] == null)
                    {
                        goalArrayA[i] = 0;
                    }

                    totalA = totalA + goalArrayA[i];
                }

                return (totalA != null) ? (int)totalA : 0;
            }
        }

        public int TotalGoalsForTeamB()
        {
            using (var repository = new MatchRepository())
            {
                var goals = repository.GetAllMatches().ToList();

                List<int?> goloviB = new List<int?>();

                foreach (var item in goals)
                {
                    goloviB.Add(item.TeamBScore);
                };

                int?[] goalArrayB = goloviB.ToArray();

                int? totalB = 0;

                for (int i = 0; i < goalArrayB.Length; i++)
                {
                    if (goalArrayB[i] == null)
                    {
                        goalArrayB[i] = 0;
                    }

                    totalB = totalB + goalArrayB[i];
                }

                return (totalB != null) ? (int)totalB : 0;
            }
        }

        public int TotalGoals()
        {
            using (var repository = new MatchRepository())
            {
                var totalA = TotalGoalsForTeamA();
                var totalB = TotalGoalsForTeamB();

                var totalGoalsScored = totalA + totalB;

                return totalGoalsScored;
            }
        }

        public int TotalMatchesPlyed()
        {
            using (var repository = new MatchRepository())
            {
                var goals = repository.GetAllMatches().ToList();

                List<int?> goloviA = new List<int?>();

                foreach (var item in goals)
                {
                    goloviA.Add(item.TeamAScore);
                };

                int?[] goalArrayA = goloviA.ToArray();

                int totalNumberOfMathces = goalArrayA.Length;

                return totalNumberOfMathces;
            }
        }

        public int TotalNumberOfTeams()
        {
            using (var repository = new TeamRepository())
            {
                var teams = repository.GetAllTeams();

                List<int> NumberOfTeams = new List<int>();

                foreach (var item in teams)
                {
                    NumberOfTeams.Add(item.Id);
                }

                int[] NumOfTeams = NumberOfTeams.ToArray();

                int totalNumberOfTeams = NumOfTeams.Length;

                return totalNumberOfTeams;
            }
        }

        public decimal AverageGoalPerTeam()
        {
            var total = TotalGoals();
            var totalNumberOfMathces = TotalMatchesPlyed();
            var totalNumberOfTeams = TotalNumberOfTeams();

            decimal? averageGoalPerTeam = 0;

            if ((decimal?)total == 0 && totalNumberOfMathces == 0)
            {
                averageGoalPerTeam = 0;
            }
            else
            {
                averageGoalPerTeam = (decimal?)total / totalNumberOfTeams;
            }

            return (decimal)averageGoalPerTeam;
        }

        public decimal AverageGoalsPerMatch()
        {
            var total = TotalGoals();
            var totalNumberOfMathces = TotalMatchesPlyed();
            var totalNumberOfTeams = TotalNumberOfTeams();

            decimal? averageGoalsPerMatch = 0;

            if ((decimal?)total == 0 && totalNumberOfMathces == 0)
            {
                averageGoalsPerMatch = 0;
            }
            else
            {
                averageGoalsPerMatch = (decimal?)total / totalNumberOfMathces;
            }

            return (decimal)averageGoalsPerMatch;
        }
    }
}
