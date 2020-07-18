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

        public static double CountAverageHours(IEnumerable<Hour> listOfHours, Func<IEnumerable<Hour>, double> daysFromStart)
        {
            var tempValue =  Double.Parse(daysFromStart.ToString());
            return  Math.Round(listOfHours.Count() / tempValue, 2);
        }
    }
}
