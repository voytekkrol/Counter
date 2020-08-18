using Counter.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace Counter
{
    public partial class MainWindow : Window
    {
        IEnumerable<Hour> listOfHours = DatabaseFromFile.Read();
        public double AverageHours { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CounterRefresh();
        }

        private void CounterRefresh()
        {
            Counter.Text = $"Average: {Counting.CountAverageHours(listOfHours, Counting.DaysFromStart)} hours";
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
            MessageBox.Show("Days from start: " + Counting.DaysFromStart(listOfHours).ToString());
        }
    }
}
