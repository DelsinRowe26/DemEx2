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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace DemEx2
{
    /// <summary>
    /// Логика взаимодействия для AutorizationRegistration.xaml
    /// </summary>
    public partial class AutorizationRegistration : Window
    {

        SqlConnection sqlconn;

        public AutorizationRegistration()
        {
            InitializeComponent();
        }

        private void AutorizationRegistrationWin_Loaded(object sender, RoutedEventArgs e)
        {
            string sqlconnect = @"Data Source = DESKTOP-R2UPGH3\DR; Initial Catalog = DemExam; Integrated Security = True";
            //DBConnect dB = new DBConnect();
            DBConnect.DataBaseConn(sqlconnect);
        }

        private void btnAutorization_Click(object sender, RoutedEventArgs e)
        {
            //string myselectquery = "SELECT * FROM [dbo].[Ychastniki$] WHERE [id_ych]= '" + tbIdNumber.Text + "' and [пароль]='" + PasswordAutor.Password + "'";
            bool Autorization;
            DBConnect.SQLQueryAutorization(tbIdNumber.Text, PasswordAutor.Password, "участники", "Почта", "пароль", out Autorization);
            if(Autorization == true)
            {
				MessageBox.Show("Добро пожаловать!");
			}
            else
            {
				MessageBox.Show("Ошибка, вы ввели неправильное имя, либо фамиилию, либо отчество");
			}
            /*using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, sqlconn))
            {
                DataTable table = new DataTable();

                dataAdapter.Fill(table);//Вылетает ошибка

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Ошибка, вы ввели неправильное имя, либо фамиилию, либо отчество");
                }
                else
                {
                    MessageBox.Show("Добро пожаловать!");
                    /*Form2 newForm = new Form2();
                    newForm.Show();
                }
            }*/
        }
    }
}
