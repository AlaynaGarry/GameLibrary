using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameLibrary.Models;
using System.Linq;
using System;

namespace GameLibrary.Data
{
    public class GameContext :DbContext
    {
        public GameContext(DbContextOptions options) : base(options) {
            
        }
        //will create the Games table in the DB using Movie.cs model
        public DbSet<Game> Games { get; set; }


    }
}
