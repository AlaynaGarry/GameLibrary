using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Models
{
    public class Game
    {
       [Required]
        public int ID { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Title { get; set; }
        public int Year { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
        public string ESRBRating { get; set; }
        public string Image { get; set; }
        //person loaned to
        public string LoanedTo { get; set; }
        public DateTime? LoanDate { get; set; }

        public Game() { }
        public Game(string title, int year, string platform, string genre, string esrbRating, string image = "")
        {
            this.Title = title;
            this.Year = year;
            this.Platform = platform;
            this.Genre = genre;
            this.ESRBRating = esrbRating;
            this.Image = image;
        }

        public void LoanOutGame(string loanTo)
        {
            this.LoanedTo = loanTo;
            LoanDate = DateTime.Now;
        }

        public void ReturnLoanedGame()
        {
            LoanDate = null;
            LoanedTo = null;
        }
    }
}
