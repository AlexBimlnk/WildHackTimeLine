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
        private Dictionary<string, int> monthDict = new Dictionary<string, int>()
        {
            {"янв", 1}, {"фев", 2}, {"мар", 3}, {"апр", 4},
            {"май", 5}, { "мая", 5}, {"июн", 6}, {"июл", 7}, {"авг", 8},
            {"сен", 9}, {"окт", 10}, {"ноя", 11}, {"дек", 12}
        };

        private static Action<Date,string[]> setDateDelegate = (example, arr) =>
        {
            if (arr.Length > 2)
                example.TrySetYear(arr[2]);
            example.TrySetMonth(arr[1]);
            example.TrySetDay(arr[0]);
        };

        //TODO логику для сета гета
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public string FullDate
        {
            get { return $"{Day}.{Month}.{Year}"; }
        }

        public Date() { }

        public Date(string data)
        {
            GetDateFromData(data);
        }

        public void GetDateFromData(string inputData)
        {
            string[] inputArray = inputData.Trim().Split(' ').
                                  Select(s => s.ToLower().Trim(',', '.', '|')).
                                  TakeWhile(s => !s.Contains(':')).ToArray();
            //if(inputArray.)
            if (inputArray.Length == 1)
                inputArray = inputArray[0].Split('.');
            setDateDelegate(this, inputArray);
        }

        private void TrySetDay(string day)
        {
            Day = int.Parse(day);
        }
        private void TrySetMonth(string month)
        {
            int resultMonth = 0;
            if(!int.TryParse(month, out resultMonth))
            {
                string key = monthDict.Keys.First(s => month.Contains(s));
                if (key != null)
                    resultMonth = monthDict[key];
            }
            Month = resultMonth;
        }
        private void TrySetYear(string year)
        {
            Year = int.Parse(year);
        }
    }
}
