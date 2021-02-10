using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BeerBot_1
{
    public class MyTopUsers
    {
        public string name { get; set; }
        public int money { get; set; }

        public MyTopUsers(string name, int money)
        {
            this.name = name;
            this.money = money;
        }
    }
}
