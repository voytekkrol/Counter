using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Counter.Classes
{
    public class Hour
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public int anHour { get; set; }

    }
}
