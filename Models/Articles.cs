using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekt_Beispiel.Models
{
    public class Article
    {

        public int ArticleId { get; set; }
        public string Articlename { get; set; }

        public string Firstname{ get; set; }
        public string Lastname { get; set; }

        public string Reason { get; set; }
        
        public double Price { get; set; }

        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public Article() : this(0,"", "", "", "", null) { }
        public Article(int id, string articlename, string firstname, string lastname, string reason ,DateTime? releaseDate)
        {
            this.ArticleId = id;
            this.Articlename = articlename;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Reason = reason;
            this.ReleaseDate = releaseDate;
        }

        public Article(int id, string articlename, string description, string imagePath, double price, DateTime? releaseDate)
        {
            this.ArticleId = id;
            this.Articlename = articlename;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Price = price;
            this.ReleaseDate = releaseDate;
        }
        public override string ToString()
        {
            return this.ArticleId + " " + this.Articlename + " " + this.Firstname + this.Lastname;
        }
    }
}
