using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace Time_tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        System.Diagnostics.Stopwatch timerStopWatch = new System.Diagnostics.Stopwatch();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.TextBlockTimer.Text = string.Format("{0}:{1}:{2}.{3}", timerStopWatch.Elapsed.Hours.ToString("00"), timerStopWatch.Elapsed.Minutes.ToString("00"), timerStopWatch.Elapsed.Seconds.ToString("00"), timerStopWatch.Elapsed.Milliseconds.ToString("00"));
        }

        private void ButtonStartClick(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                timerStopWatch.Start();
                dispatcherTimer.Start();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Time Tracker", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonStopClick(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                timerStopWatch.Stop();
                dispatcherTimer.Stop();
                MessageBoxResult messResuly = MessageBox.Show("Are you want to save data ?", "Time Tracker", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messResuly.Equals(MessageBoxResult.Yes))
                {
                    var sqltoLinqDataContract = new sqltoLinqDataDataContext();
                    TimeTrickTable AddTime = new TimeTrickTable
                    {
                        //Autoinc = 1,
                        EntryDate = DateTime.Today,
                        ETime = TimeSpan.Parse(this.TextBlockTimer.Text)
                    };
                    sqltoLinqDataContract.TimeTrickTables.InsertOnSubmit(AddTime);
                    sqltoLinqDataContract.SubmitChanges();
                }
            }
            catch(Exception error)
            {
                 MessageBox.Show(error.Message, "Time Tracker", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonResetClick(object sender, System.Windows.RoutedEventArgs e)
        {
            timerStopWatch.Reset();
            this.TextBlockTimer.Text = "00:00:00.00";
            dispatcherTimer.Stop();
        }

        private void ButtonReportClick(object sender, System.Windows.RoutedEventArgs e)
        {
            new WindowReportMaker().Show();
        }

        private void ButtonExitClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void titelBarMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }


    }
}
