using GameLibrary.Models;
using GameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Data
{
    public class GameDAL : IDataAccessLayer
    {
       /* private static List<Game> GameList = new List<Game>()
        {
             new Game("Skyrim", 2011, "Xbox 360", "Action Adventure RPG", "M", "skyrim.png"),
             new Game("Dragon Age: Origins", 2009, "Xbox 360", "Action Adventure RPG", "M", "dao.png"),
             new Game("Dragon Age II", 2011, "Xbox 360", "Action Adventure RPG", "M", "da2.png"),
             new Game("Dragon Age: Inquistion", 2014, "Xbox One", "Action Adventure RPG", "M", "dai.png"),
             new Game("Assassins Creed", 2007, "Playstation 3", "Action Adventure", "M", "ac1.png")
        };*/

        private GameContext db;

        public GameDAL(GameContext indb) {
            this.db = indb;
        }

        public void AddGame(Game game)
        {
            //game.ID = 0;
            db.Add(game);
            db.SaveChanges();
            //GameList.Add(game);
        }

        public Game GetGame(int? id)
        {
            return db.Games.FirstOrDefault(m => m.ID == id);

            /*Game foundGame = null;
            if (id != null)
            {
                GameList.ForEach(m =>
                {
                    if (m.ID == id)
                    {
                        foundGame = m;
                    }
                });
            }
            return foundGame;*/
        }

        public IEnumerable<Game> GetGames()
        {
            //return GameList;
            return db.Games.ToList();
        }

        public void RemoveGame(int? id)
        {
            if (id > 0) {
                db.Games.Remove(db.Games.Find(id));
                db.SaveChanges();
            }

            /*var foundGame = GetGame(id);
            if (foundGame != null)
            {
                GameList.Remove(foundGame);
            }*/
        }

        public void UpdateGame(Game game)
        {
            db.Update(game);
            db.SaveChanges();
        }

        /*public IEnumerable<Game> SearchForGames(string key)
        {
            List<Game> tempGame = new List<Game>();
            foreach (var g in GameList)
            {
                if (g.Title.ToUpper().Contains(key.ToUpper()))
                {
                    tempGame.Add(g);
                }
            }
            return tempGame;
        }

        public IEnumerable<Game> FilterCollection(string genre, string platform, string ersb)
        {
            List<Game> tempLib = new List<Game>(0);
            bool genreC = genre == null;
            bool platformC = platform == null;
            bool ersbC = ersb == null;

            foreach (var g in GameList)
            {
                if ((genreC || g.Genre.ToUpper().Contains(genre.ToUpper())) && (platformC || g.Platform.ToUpper().Contains(platform.ToUpper())) && (ersbC || g.ESRBRating.ToUpper().Contains(ersb.ToUpper()))) {
                    tempLib.Add(g);
                }

            }
            return tempLib;
        }*/
    }
}
