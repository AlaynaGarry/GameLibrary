using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibrary.Models;

namespace GameLibrary
{
    public interface IDataAccessLayer
    {
        IEnumerable<Game> GetGames();
        void AddGame(Game game);
        void RemoveGame(int? id);
        Game GetGame(int? id);
        void UpdateGame(Game game);

        /*IEnumerable<Game> SearchForGames(string key);
        IEnumerable<Game> FilterCollection(string genre, string platform, string esrbRating);*/

    }
}
