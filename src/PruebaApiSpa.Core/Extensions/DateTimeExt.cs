using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PruebaApiSpa.Extensions
{
    public static class DateTimeExt
    {
        public static int GetWeekOfMonth(this DateTime date)
        {
            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                date = date.AddDays(1);

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        }

        public static int GetWeekOfYear(this DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static List<DateTime> GetDaysOfWeek(this int weekNumber, int year)
        {
            var days = (weekNumber - 1) * 7;
            DateTime date = new DateTime(year, 1, 1);
            date = date.AddDays(days);

            var firtDay = date.GetFirstDayOfWeek();

            var daysOutpput = new List<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                daysOutpput.Add(firtDay.AddDays(i));
            }
            return daysOutpput;
        }


        /// <summary>
        /// Returns the first day of the week that the specified date 
        /// is in. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(this DateTime dayInWeek)
        {
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != DayOfWeek.Sunday)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

    }
}
