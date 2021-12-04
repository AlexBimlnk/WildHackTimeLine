using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WildHackWebApp.BL
{
    [Serializable]
    public class Date
    {
        private int[] daysInMonths = { -1, 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private int day;
        private int month;
        private int year;
        public int Day
        {
            set
            {
                if (value < 1)
                    day = -1;
                else
                {
                    if (month == 2)
                    {
                        if (value < 29)
                            day = value;
                        else
                        {
                            if (value == 29 && year % 4 == 0)
                                day = 29;
                            else
                                day = -1;
                        }
                            
                    }
                    else
                    {
                        if (value > daysInMonths[month])
                            day = -1;
                        else
                            day = value;
                    }
                }
            }
            get
            {
                return day;
            }
        }

        public int Month
        {
            set
            {
                if (value > 12 || value < 1)
                    month = -1;
                else
                    month = value;
            }
            get
            {
                return month;
            }
        }

        public int Year
        {
            set
            {
                if (value > DateTime.Now.Year || value < 1)
                    year = -1;
                else
                    year = value;
            }
            get
            {
                return year;
            }
        }

        public string FullDate
        {
            get { return $"{Day}.{Month}.{Year}"; }
        }
    }
}
