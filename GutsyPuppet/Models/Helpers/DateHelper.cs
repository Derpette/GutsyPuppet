using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GutsyPuppet.Models.Helpers
{
    public class DateHelper
    {
        public static DateTime GetPreviousWorkday()
        {
            var now = DateTime.UtcNow;
            DateTime previous = now;
            do
            {
                previous = previous.AddDays(-1);
            } while (previous.DayOfWeek == DayOfWeek.Saturday || previous.DayOfWeek == DayOfWeek.Sunday);
            return previous.Date;
        }

    }
}