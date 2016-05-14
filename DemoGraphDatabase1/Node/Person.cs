using ConsoleApplication2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoGraphDatabase1.Node
{
    public class Person:Actor
    {
        public string roles { set; get; }
        public string login { set; get; }
        public string password { set; get; }
    }
}
