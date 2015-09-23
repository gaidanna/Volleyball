using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Middleware
{
    public class DataBaseSpy : IDataBase
    {
        public static Dictionary<Guid, Team> TeamsList = new Dictionary<Guid, Team>();
        public static Dictionary<Guid, Player> PlayersList = new Dictionary<Guid, Player>();
        public static Dictionary<Guid, Game> GamesList = new Dictionary<Guid, Game>();

        public void CreateGame(Game game)
        {
            GamesList.Add(game.Id, game);
        }

        public Game ReadGame(Guid id)
        {
            Game result;
            if (GamesList.TryGetValue(id, out result))
            {
                return result;
            }
            return null;
        }

        public void UpdateGame(Game game)
        {
            Game result;
            if (GamesList.TryGetValue(game.Id, out result))
            {
                result = game;
            }
        }

        public void DeleteGame(Game game)
        {
            GamesList.Remove(game.Id);
        }

        public void CreateTeam(Team team)
        {
            TeamsList.Add(team.Id, team);
        }

        public Team ReadTeam(Guid id)
        {
            Team result;
            if (TeamsList.TryGetValue(id, out result))
            {
                return result;
            }
            return null;
        }

        public void UpdateTeam(Team team)
        {
            Team result;
            if (TeamsList.TryGetValue(team.Id, out result))
            {
                result = team;
            }
        }

        public void DeleteTeam(Team team)
        {
            TeamsList.Remove(team.Id);
        }

        public void CreatePlayer(Player player)
        {
            PlayersList.Add(player.Id, player);
        }

        public Player ReadPlayer(Guid id)
        {
            Player result;
            if (PlayersList.TryGetValue(id, out result))
            {
                return result;
            }
            return null;
        }

        public void UpdatePlayer(Player player)
        {
            Player result;
            if (PlayersList.TryGetValue(player.Id, out result))
            {
                result = player;
            }
        }

        public void DeletePlayer(Player player)
        {
            PlayersList.Remove(player.Id);
        }
    }
}
