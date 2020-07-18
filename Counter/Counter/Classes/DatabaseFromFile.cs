using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Classes
{
    public class DatabaseFromFile
    {
        public static IEnumerable<Hour> Read()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                IEnumerable<Hour> tempListOfHours;
                conn.CreateTable<Hour>();
                return tempListOfHours = conn.Table<Hour>().ToList();
            }
        }

        public static IEnumerable<Hour> AddHour()
        {
            Hour hour = new Hour();
            hour.dateTime = DateTime.Today;
            hour.anHour = 1;

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                IEnumerable<Hour> tempListOfHours;
                connection.CreateTable<Hour>();
                connection.Insert(hour);
                return tempListOfHours = connection.Table<Hour>().ToList();
            }
        }

        public static IEnumerable<Hour> DeleteHour()
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                IEnumerable<Hour> tempListOfHours;
                connection.CreateTable<Hour>();
                Hour hour = connection.Table<Hour>().Last<Hour>();
                connection.Delete(hour);
                return tempListOfHours = connection.Table<Hour>().ToList();
            }
        }
    }
}
