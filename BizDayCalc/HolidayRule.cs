using System;

namespace BizDayCalc
{
    public class HolidayRule : IRule
    {
        public static readonly int[,] UsHolidays = 
        {
            {1, 1}, // New Year's day
            {7, 4}, // Independence day
            {12, 24}, // Christmas eve
            {12, 25}, // Christmas day
        };

        public bool CheckIsBusinessDay(DateTime date)
        {
            for (int day = 0; day <= UsHolidays.GetUpperBound(0); day++)
            {
                if (date.Month == UsHolidays[day, 0] &&
                    date.Day == UsHolidays[day, 1])
                        return false;
            }

            return true;
        }
    }
}
