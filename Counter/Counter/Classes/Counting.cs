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
            DateTime firstDay = listOfHours.ElementAt<Hour>(0).dateTime;
            return DateTime.Today.Subtract(firstDay).TotalDays;
        }

        public static double CountAverageHours(IEnumerable<Hour> listOfHours, Func<IEnumerable<Hour>, double> daysFromStart)
        {
            var tempValue =  Double.Parse(daysFromStart.ToString());
            return  Math.Round((double)listOfHours.Count() / tempValue, 2);
        }
    }
}
