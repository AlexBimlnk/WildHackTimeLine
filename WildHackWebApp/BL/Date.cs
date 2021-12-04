using System;
using System.Collections.Generic;
using System.Linq;

namespace WildHackWebApp.BL
{
    [Serializable]
    public class Date
    {
        private int[] _daysInMonths = { -1, 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private Dictionary<string, int> _monthDict = new Dictionary<string, int>()
        {
            {"янв", 1}, {"фев", 2}, {"мар", 3}, {"апр", 4},
            {"май", 5}, { "мая", 5}, {"июн", 6}, {"июл", 7}, {"авг", 8},
            {"сен", 9}, {"окт", 10}, {"ноя", 11}, {"дек", 12}
        };

        private static Action<Date, string[]> _setDateDelegate = (example, arr) =>
        {
            if (arr.Length > 2)
                example.TrySetYear(arr[2]);
            else
                example.Year = DateTime.Now.Year;
            example.TrySetMonth(arr[1]);
            example.TrySetDay(arr[0]);
        };

        private int _day;
        private int _month;
        private int _year;

        public int Day
        {
            set
            {
                _day = -1;
                if (value >= 1 && value <= 31)
                {
                    if (_month == 2)
                    {
                        if (value < 29)
                            _day = value;
                        else if (value == 29 && _year % 4 == 0)
                            _day = 29;
                    }
                    else if(value <= _daysInMonths[Month])
                        _day = value;
                }
            } 
            get { return _day; }
        }

        public int Month
        {
            set
            {
                if (value > 12 || value < 1)
                    _month = -1;
                else
                    _month = value;
            }
            get { return _month; }
        }

        public int Year
        {
            set
            {
                if (value > DateTime.Now.Year || value < 1)
                    _year = -1;
                else
                    _year = value;
            }
            get { return _year; }
        }

        public string FullDate
        {
            get { return $"{Day:d2}.{Month:d2}.{Year:d4}"; }
        }

        public Date() { }

        public Date(string data)
        {
            SetDateFromData(data);
        }

        public void SetDateFromData(string inputData)
        {
            inputData = inputData.Trim();
            string[] resultArray = inputData.Split(' ');
            DateTime dateTime;
            if (!DateTime.TryParse(inputData, out dateTime) || resultArray.Length > 1)
            {
                resultArray = resultArray.Select(s => s.ToLower().Trim(',', '.', '|')).
                                      TakeWhile(s => !s.Contains(':')).ToArray();

                if (resultArray.Length == 1)
                    resultArray = resultArray[0].Split('.');
                _setDateDelegate(this, resultArray);
            }
            else
            {
                Year = dateTime.Year;
                Month = dateTime.Month; 
                Day = dateTime.Day;
            }
        }

        private void TrySetDay(string inputDay)
        {
            Day = int.Parse(inputDay);
        }
        private void TrySetMonth(string inputMonth)
        {
            int resultMonth = 0;
            if(!int.TryParse(inputMonth, out resultMonth))
            {
                string key = _monthDict.Keys.First(s => inputMonth.Contains(s));
                if (key != null)
                    resultMonth = _monthDict[key];
            }
            Month = resultMonth;
        }
        private void TrySetYear(string inputYear)
        {
            Year = int.Parse(inputYear);
        }
    }
}
