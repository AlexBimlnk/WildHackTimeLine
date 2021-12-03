using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WildHackWebApp.BL
{
    [Serializable]
    public class Date
    {
        //TODO логику для сета гета
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public string FullDate
        {
            get { return $"{Day}.{Month}.{Year}"; }
        }
    }
}
