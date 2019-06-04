using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMediaBrowser.Models
{
    public class MoviesModel
    {
        public MoviesModel()
        {

        }
        public string Title { get; set; }
        public int Genre { get; set; }
        public int Year { get; set; }
        public int Director { get; set; }

    }
}