using Counter.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace Counter
{
    public partial class MainWindow : Window
    {
        IEnumerable<Hour> listOfHours;
        public double AverageHours { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            listOfHours = DatabaseFromFile.Read();
            CounterRefresh();
        }

        private void CounterRefresh()
        {
           
            Counter.Text = $"Average: {CountAverageHours()} hours";
        }

        private void Exit_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void AddButton_Clicked(object sender, RoutedEventArgs e)
        {
            listOfHours = DatabaseFromFile.AddHour();
            CounterRefresh();
        }

        private void SubtractButton_Clicked(object sender, RoutedEventArgs e)
        {
            listOfHours = DatabaseFromFile.DeleteHour();
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
            return AverageHours = Math.Round(listOfHours.Count() / DaysFromStart(), 2);
        }


    }
}
