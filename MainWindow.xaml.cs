using System;
using System.Collections.Generic;
using System.Configuration;
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
using MySql.Data.MySqlClient;

namespace PrestonMarathonApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        public MainWindow()
        {
            InitializeComponent();
            MySqlConnection con = new MySqlConnection(constr);
            string getAccountQuery = "SELECT id,name FROM runner where id =1";
            MySqlCommand cmd = new MySqlCommand(getAccountQuery);
            cmd.Connection = con;
            con.Open();
            MySqlDataReader data = cmd.ExecuteReader();
            if(data.Read())
            {
                db.Text = data.GetString(1);
            }
        }
       
        private void amtr_runner_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Close();
        }
    }
}
