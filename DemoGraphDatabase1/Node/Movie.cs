using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoGraphDatabase1.Node
{
    public class Movie
    {
        public int runtime { set; get; }
        public string homepage { set; get; }
        public int version { set; get; }
        public string imdbId { set; get; }
        public string trailer { set; get; }
        public string studio { set; get; }
        public string genre { set; get; }
        public DateTimeOffset lastModified { set; get; }
        public string imageUrl { set; get; }
        public string language { set; get; }
        public string tagline { set; get; }
        public string title { set; get; }
        public DateTimeOffset releaseDate { set; get; }
        public int id { set; get; }
        public string description { set; get; }
    }
}
