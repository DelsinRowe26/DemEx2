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
            DataTable dt;
            DBConnect.LoadedDB(sql, out dt);
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
            DBConnect.DateFilter(sql, Date, out dt);
			DGDB.ItemsSource = dt.DefaultView;
		}
	}
}
