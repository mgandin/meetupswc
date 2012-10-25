using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulerDotNet
{
    public class TimeServices
    {

        public static bool IsPastDue(DateTime date)
        {

            return date.CompareTo(DateTime.Now) < 0;
        }

        public static bool IsWorkDay(DateTime date)
        {
            return false;
        }

        public static bool IsHoliday(DateTime date)
        {
            return false;
        }
    }
}
