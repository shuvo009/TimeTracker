using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Time_tracker
{
	/// <summary>
	/// Interaction logic for WindowReportMaker.xaml
	/// </summary>
	public partial class WindowReportMaker : Window
	{
		public WindowReportMaker()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

		private void ButtonSearchbyDateClick(object sender, System.Windows.RoutedEventArgs e)
		{
            var sqlDataContract = new sqltoLinqDataDataContext();
            var reportmaker = from timedb in sqlDataContract.TimeTrickTables where timedb.EntryDate ==Convert.ToDateTime(DatePickerTimer.Text) select timedb;
            DataGridReportMaker.ItemsSource = reportmaker;
            sqlDataContract.Dispose();
        }

        private void ButtonSearchbyMonthClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var sqlDataContract = new sqltoLinqDataDataContext();
            var monthely = from u in sqlDataContract.TimeTrickTables group u by u.EntryDate.Value.Month into g select new { EntryDate = g.Key, ETime = new TimeSpan(g.Sum(r => r.ETime.Value.Ticks)) };
            DataGridReportMaker.ItemsSource = monthely;
            sqlDataContract.Dispose();
        }

		private void ButtonReportByDateClick(object sender, System.Windows.RoutedEventArgs e)
		{
            this.ButtonReport.IsEnabled = false;
            Mouse.OverrideCursor = Cursors.Wait;
            var sqlDataContract = new sqltoLinqDataDataContext();
            var reportmaker = from timedb in sqlDataContract.TimeTrickTables where timedb.EntryDate == Convert.ToDateTime(DatePickerTimer.Text) select timedb;
            TimerDataSet reportDataset = new TimerDataSet();
            foreach (var item in reportmaker)
            {
                reportDataset.TimerDataTable.Rows.Add(item.EntryDate, item.ETime);
            }
            WindowReportViewer reportVew = new WindowReportViewer();
            CrystalReport1 cyReport = new CrystalReport1();
            cyReport.SetDataSource(reportDataset);
            reportVew.ReportViewerView.ViewerCore.ReportSource=cyReport;
            reportVew.Show();
            sqlDataContract.Dispose();
            reportDataset.Dispose();
            this.ButtonReport.IsEnabled = true;
            Mouse.OverrideCursor = null;
		}

        private void ButtonReportByMonthClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ButtonReport.IsEnabled = false;
            Mouse.OverrideCursor = Cursors.Wait;
            var sqlDataContract = new sqltoLinqDataDataContext();
            var reportmaker = from u in sqlDataContract.TimeTrickTables group u by u.EntryDate.Value.Month into g select new { EntryDate = g.Key, ETime = new TimeSpan(g.Sum(r => r.ETime.Value.Ticks)) };
            TimerDataSet reportDataset = new TimerDataSet();
            foreach (var item in reportmaker)
            {
                reportDataset.TimerDataTable.Rows.Add(item.EntryDate, item.ETime);
            }
            WindowReportViewer reportVew = new WindowReportViewer();
            CrystalReport1 cyReport = new CrystalReport1();
            cyReport.SetDataSource(reportDataset);
            reportVew.ReportViewerView.ViewerCore.ReportSource = cyReport;
            reportVew.Show();
            sqlDataContract.Dispose();
            reportDataset.Dispose();
            this.ButtonReport.IsEnabled = true;
            Mouse.OverrideCursor = null;
        }

		private void RadioButtonByDateChecked(object sender, System.Windows.RoutedEventArgs e)
		{
            this.ButtonSearch.Click += new RoutedEventHandler(ButtonSearchbyDateClick);
            this.ButtonReport.Click += new RoutedEventHandler(ButtonReportByDateClick);
            this.DatePickerTimer.IsEnabled = true;
		}

		private void RadioButtonByDateUnchecked(object sender, System.Windows.RoutedEventArgs e)
		{
            this.ButtonSearch.Click -= new RoutedEventHandler(ButtonSearchbyDateClick);
            this.ButtonReport.Click -= new RoutedEventHandler(ButtonReportByDateClick);
            this.DatePickerTimer.IsEnabled =false;
		}

		private void RadioButtonByMonthChecked(object sender, System.Windows.RoutedEventArgs e)
		{
            this.ButtonSearch.Click += new RoutedEventHandler(ButtonSearchbyMonthClick);
            this.ButtonReport.Click += new RoutedEventHandler(ButtonReportByMonthClick);
		}

		private void RadioButtonByMonthUnchecked(object sender, System.Windows.RoutedEventArgs e)
		{
            this.ButtonSearch.Click -= new RoutedEventHandler(ButtonSearchbyMonthClick);
            this.ButtonReport.Click -= new RoutedEventHandler(ButtonReportByMonthClick);
		}
	}
}