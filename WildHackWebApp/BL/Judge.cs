using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WildHackWebApp.Models;

namespace WildHackWebApp.BL
{
    /// <summary>
    /// Содержит методы для проверки новостей на совпадение.
    /// </summary>
    public static class Judge
    {
        /// <summary>
        /// Удаляет из одной коллекции новостей повторяющиеся.
        /// </summary>
        public static List<EcologyEvent> ClearEqualEvents(List<EcologyEvent> ecoEvents)
        {
            List<bool> equal = new List<bool>(Enumerable.Repeat(false, ecoEvents.Count).ToArray());
            for (int i = 0; i < ecoEvents.Count - 1; i++)
            {
                if (!equal[i])
                {
                    for (int j = i + 1; j < ecoEvents.Count; j++)
                    {
                        if (NearDates(ecoEvents[i], ecoEvents[j]) && IsEventsEqual(ecoEvents[i], ecoEvents[j]))
                            equal[j] = true;
                    }
                }
            }
            for (int i = ecoEvents.Count - 1; i > 0; i--)
            {
                if (equal[i])
                {
                    equal.RemoveAt(i);
                    ecoEvents.RemoveAt(i);
                }
            }
            return ecoEvents;
        }

        /// <summary>
        /// Удаляет из коллекции свежих новостей повторяющиеся со старыми (взятыми из базы данных).
        /// </summary>
        public static List<EcologyEvent> CompareWithOld(List<EcologyEvent> newEco, List<EcologyEvent> oldEco)
        {
            if (newEco.Count == 0 || newEco == null)
                return null;
            for (int i = newEco.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < oldEco.Count; j++)
                {
                    if (NearDates(newEco[i], oldEco[j]) && IsEventsEqual(newEco[i], oldEco[j]))
                    {
                        newEco.RemoveAt(i);
                        break;
                    }
                }
            }
            return newEco;
        }
        
        /// <summary>
        /// Проверяет две новости на близость дат. Возвращает True если интервал между датами публикаций не больше interval в днях.
        /// </summary>
        public static bool NearDates(EcologyEvent first, EcologyEvent second, int interval = 2)
        {
            Date date1 = new Date(first.Date), date2 = new Date(second.Date);
            if (Math.Abs(date1.Year - date2.Year) > 1)
                return false;
            else
            {
                int days1 = 0, days2 = 0;
                if (date1.Year != date2.Year)
                {
                    if (date1.Year < date2.Year)
                    {
                        if (date2.Year - 1 % 4 == 0)
                            days2 += 366;
                        else
                            days2 += 365;
                    }
                    else
                    {
                        if (date1.Year - 1 % 4 == 0)
                            days1 += 366;
                        else
                            days1 += 365;
                    }
                }
                for (int i = 1; i < date1.Month; i++)
                {
                    if (i == 2)
                    {
                        if (date1.Year % 4 == 0)
                            days1 += 29;
                        else
                            days1 += 28;
                    }
                    else
                        days1 += date1.DaysInMonths[i];
                }
                days1 += date1.Day;
                for (int i = 1; i < date2.Month; i++)
                {
                    if (i == 2)
                    {
                        if (date2.Year % 4 == 0)
                            days2 += 29;
                        else
                            days2 += 28;
                    }
                    else
                        days2 += date2.DaysInMonths[i];
                }
                days2 += date2.Day;
                if (Math.Abs(days1 - days2) > interval)
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// Проверяет две новости на совпадение.
        /// </summary>
        public static bool IsEventsEqual(EcologyEvent first, EcologyEvent second)
        {
            return FuzzyComparer.IsFuzzyEqual(first.Title, second.Title);
        }

        public static void SortByDate(List<EcologyEvent> ecologyEvents)
        {
            if (ecologyEvents == null || ecologyEvents.Count == 0)
                return;
            ecologyEvents.Sort((ecoEvent1, ecoEvent2) =>
            {
                int year1 = int.Parse(ecoEvent1.Date.Substring(6, 4));
                int year2 = int.Parse(ecoEvent2.Date.Substring(6, 4));
                if (year1 == year2)
                {
                    int month1 = int.Parse(ecoEvent1.Date.Substring(3, 2));
                    int month2 = int.Parse(ecoEvent2.Date.Substring(3, 2));
                    if (month1 == month2)
                    {
                        int day1 = int.Parse(ecoEvent1.Date.Substring(0, 2));
                        int day2 = int.Parse(ecoEvent2.Date.Substring(0, 2));
                        if (day1 == day2)
                        {
                            return 0;
                        }
                        else
                        {
                            if (day1 > day2)
                            {
                                return 1;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                    else
                    {
                        if (month1 > month2)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                else
                {
                    if (year1 > year2)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            });
        }
    }
}
