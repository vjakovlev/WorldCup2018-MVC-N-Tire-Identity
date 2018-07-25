using System.Data.Entity;
using WorldCup.Data.Model;

namespace WorldCup.Data
{
    internal class WorldCupDbInitializer : DropCreateDatabaseIfModelChanges<WorldCupDbContext>
    {
        protected override void Seed(WorldCupDbContext context)
        {
            var position = new Position
            {
                Name = "GK"
            };

            context.Positions.Add(position);

            context.Positions.Add(new Position
            {
                Name = "CB"
            });

            context.Positions.Add(new Position
            {
                Name = "RB"
            });

            context.Positions.Add(new Position
            {
                Name = "LB"
            });

            context.Positions.Add(new Position
            {
                Name = "CM"
            });

            context.Positions.Add(new Position
            {
                Name = "AMF"
            });

            context.Positions.Add(new Position
            {
                Name = "ST"
            });

            var continent = new Continent
            {
                Name = "Asia"
            };

            context.Continents.Add(continent);

            context.Continents.Add(new Continent
            {
                Name = "Africa"
            });

            context.Continents.Add(new Continent
            {
                Name = "Australia"
            });

            context.Continents.Add(new Continent
            {
                Name = "North America"
            });

            context.Continents.Add(new Continent
            {
                Name = "South America"
            });

            context.Continents.Add(new Continent
            {
                Name = "Europe"
            });

            var team = new Team
            {
                Name = "Argentina",
                ContinentId = 5,
                Coatch = "JORGE SAMPAOLI",
                ShortDescription = "The Argentinian led Chile to the knockout stages at Brazil 2014, and his brand of high-tempo pressing football has now helped his home country to Russia 2018.",
                PhotoUrl = "~/Images/flags/Argentina.png",
                PhotoAlt = "Argentina Flag"
            };

            context.Teams.Add(team);

            context.Teams.Add(new Team
            {
                Name = "Australia",
                ContinentId = 3,
                Coatch = "BERT VAN MARWIJK",
                ShortDescription = "Bert van Marwijk was appointed Australia coach in January, having assumed the reins from Ange Postecoglou who resigned after the Socceroos qualified in November 2017.",
                PhotoUrl = "~/Images/flags/Australia.png",
                PhotoAlt = "Australia Flag"
            });

            context.Teams.Add(new Team
            {
                Name = "Belgium",
                ContinentId = 6,
                Coatch = "ROBERTO MARTINEZ",
                ShortDescription = "The former Everton and Swansea coach was a somewhat surprising candidate to replace Marc Wilmots in 2016, having coached solely at club level in England.",
                PhotoUrl = "~/Images/flags/Belgium.png",
                PhotoAlt = "Belgium Flag"
            });

            context.Teams.Add(new Team
            {
                Name = "Brazil",
                ContinentId = 5,
                Coatch = "TITE",
                ShortDescription = "Brazil’s transformation since Tite arrived in June 2016 has been nothing short of remarkable. Sixth in the CONMEBOL standings when he took over, they won nine consecutive games.",
                PhotoUrl = "~/Images/flags/Brazil.png",
                PhotoAlt = "Brazil Flag"
            });

            context.Teams.Add(new Team
            {
                Name = "Costa Rica",
                ContinentId = 4,
                Coatch = "OSCAR RAMIREZ",
                ShortDescription = "Having previously worked as an assistant coach for Los Ticos, first in 2006 and then in 2015, Ramirez succeeded Paulo Wanchope to take the main role in August 2015.",
                PhotoUrl = "~/Images/flags/CostaRica.png",
                PhotoAlt = "Costa Rica Flag"
            });

            context.Teams.Add(new Team
            {
                Name = "Croatia",
                ContinentId = 6,
                Coatch = "ZLATKO DALIC",
                ShortDescription = "Having replaced Ante Cacic as Croatia coach in October 2017, Dalic led the Balkan nation through a play-off, where they defeated Greece 4-1 on aggregate to secure their spot at Russia 2018.",
                PhotoUrl = "~/Images/flags/Croatia.png",
                PhotoAlt = "Croatia Flag"
            });

            context.Teams.Add(new Team
            {
                Name = "Denmark",
                ContinentId = 4,
                Coatch = "AGE HAREIDE",
                ShortDescription = "Hareide succeeded Denmark’s longest-serving coach in Morten Olsen after the Scandinavian country’s failure to qualify for UEFA EURO 2016. A former Norway international defender and coach.",
                PhotoUrl = "~/Images/flags/Denmark.png",
                PhotoAlt = "Denmark Flag"
            });

            context.Teams.Add(new Team
            {
                Name = "Egypt",
                ContinentId = 1,
                Coatch = "HÉCTOR CÚPER",
                ShortDescription = "A former coach of Valencia and Internazionale, Cuper took charge of Egypt in March 2015 and led the Pharaohs to the 2017 CAF Africa Cup of Nations final. The Argentinian then guided the North Africans.",
                PhotoUrl = "~/Images/flags/Egypt.png",
                PhotoAlt = "Egypt Flag"
            });

            context.Teams.Add(new Team
            {
                Name = "England",
                ContinentId = 6,
                Coatch = "GARETH SOUTHGATE",
                ShortDescription = "Southgate succeeded Sam Allardyce as caretaker England coach in September 2016 before being formally handed the reins on 30 November 2016. A former Three Lions defender, who was part of England’s campaigns at France 1998.",
                PhotoUrl = "~/Images/flags/England.png",
                PhotoAlt = "England Flag"
            });

            context.Teams.Add(new Team
            {
                Name = "France",
                ContinentId = 6,
                Coatch = "DIDIER DESCHAMPS",
                ShortDescription = "A FIFA World Cup winner as a player, having captained France to glory in 1998, Deschamps has coached Les Bleus since 2012. The former Monaco, Juventus and Marseille boss guided his team to top spot in Group A.",
                PhotoUrl = "~/Images/flags/France.png",
                PhotoAlt = "France Flag"
            });

            context.Teams.Add(new Team
            {
                Name = "Germany",
                ContinentId = 6,
                Coatch = "JOACHIM LOW",
                ShortDescription = "Low has been Germany coach since 2006, having previously served as assistant to Jurgen Klinsmann. He has led the team to tremendous success during his decade-plus in charge, lifting the FIFA World Cup in 2014.",
                PhotoUrl = "~/Images/flags/Germany.png",
                PhotoAlt = "Germany Flag"
            });

            //var player = new Player
            //{
            //    Name = "Viktor",
            //    Age = 12,
            //    TeamId = 2,
            //    PositionId = 2
            //};

            //context.Players.Add(player);

            //context.Players.Add(new Player
            //{
            //    Name = "Petar",
            //    Age = 12,
            //    TeamId = 3,
            //    PositionId = 3
            //});

        }
    }
}
