using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class Actor
    {
        public Actor() { }

        public string name { get; set; }
        public DateTimeOffset lastModified { get; set; }
        public string birthplace;
        public int id { get; set; }
        public double version { set; get; }
        public string biography { get; set; }
        public string profileImageUrl { set; get; }
    }
}
