using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Classes
{
    public class Counting
    {
        
        public static double DaysFromStart(IEnumerable<Hour> listOfHours)
        {
            var firstDay = listOfHours.ElementAt<Hour>(0).dateTime;
            return DateTime.Today.Subtract(firstDay).TotalDays;
        }

        public static double CountAverageHours(IEnumerable<Hour> listOfHours, double daysFromStart)
        {
            string tempValue =  daysFromStart.ToString();
            var tempValueToCount = Double.Parse(tempValue);
            return  Math.Round(listOfHours.Count() / tempValueToCount, 2);
        }
    }
}
