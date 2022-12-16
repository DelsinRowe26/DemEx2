using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace DemEx2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        //SqlConnection conect;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainSystem_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = @"Data Source = DESKTOP-R2UPGH3\DR; Initial Catalog = DemExam; Integrated Security = True";
            string nameTable = "Plan";
            DataTable dt;
            DBConnect.LoadedDB(sql, nameTable , out dt);

            cmbFilterDirection.DisplayMemberPath = "Событие";
            cmbFilterDirection.ItemsSource = dt.AsDataView();
            cmbFilterDirection.SelectedIndex = -1;


            DGDB.ItemsSource = dt.DefaultView;
        }

        private void btnRegistrationAutorization_Click(object sender, RoutedEventArgs e)
        {
            AutorizationRegistration autorizationRegistration = new AutorizationRegistration();
            autorizationRegistration.ShowDialog();
        }

		private void btnFilter_Click(object sender, RoutedEventArgs e)
		{
			string sql = @"Data Source = DESKTOP-R2UPGH3\DR; Initial Catalog = DemExam; Integrated Security = True";
			DataTable dt;
            string Date = FilterDate.Text;
            string nameTable = "Plan";

			DBConnect.DateFilter(sql, nameTable, Date, out dt);
			DGDB.ItemsSource = dt.DefaultView;
		}

		private void cmbFilterDirection_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string sql = @"Data Source = DESKTOP-R2UPGH3\DR; Initial Catalog = DemExam; Integrated Security = True";
			DataTable dt;
			string nameEvent = cmbFilterDirection.Text;
			string nameTable = "Plan";

            DBConnect.EventFilter(sql, nameTable, nameEvent, out dt);
			DGDB.ItemsSource = dt.DefaultView;
		}


	}
}
