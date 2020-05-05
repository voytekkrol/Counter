using Counter.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Counter
{
    public partial class MainWindow : Window
    {
        List<Hour> listOfHours;
        public double AverageHours { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            listOfHours = new List<Hour>();
            ReadDatabase();
            CounterRefresh();
        }

        void ReadDatabase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Hour>();
                listOfHours = conn.Table<Hour>().ToList();
            }
        }
        private void CounterRefresh()
        {
           
            Counter.Text = $"Average: {CountAverageHours().ToString()} hours";
        }

        private void Exit_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void AddButton_Clicked(object sender, RoutedEventArgs e)
        {
            Hour hour = new Hour();
            hour.dateTime = DateTime.Today;
            hour.anHour = 1;

            using(SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Hour>();
                connection.Insert(hour);
                listOfHours = connection.Table<Hour>().ToList();
                
            }
            CounterRefresh();
        }

        private void SubtractButton_Clicked(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Hour>();
                Hour hour = connection.Table<Hour>().Last<Hour>();
                connection.Delete(hour);
                listOfHours = connection.Table<Hour>().ToList();
            }
            CounterRefresh();
        }

        private void ShowTotalDays_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Days from start: " + DaysFromStart().ToString());
        }

        public double DaysFromStart()
        {
            DateTime firstDay = listOfHours.ElementAt<Hour>(0).dateTime;
            return  DateTime.Today.Subtract(firstDay).TotalDays;

        }

        private double CountAverageHours()
        {
            return AverageHours = Math.Round((listOfHours.Count / DaysFromStart()), 2);
        }


    }
}
