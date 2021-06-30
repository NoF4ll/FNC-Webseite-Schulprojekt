using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekt_Beispiel.Models
{
    public class Comment
    {
        public string Text { get; set; }
        public string Creator { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }

        public Comment() : this("", "", 1, DateTime.Now, "") { }

        public Comment(string text, string creator, int rating, DateTime date, string imagePath)
        {
            this.Text = text;
            this.Creator = creator;
            this.Rating = rating;
            this.Date = date;
            this.ImagePath = imagePath;
        }
    }
}
