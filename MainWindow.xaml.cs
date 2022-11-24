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


namespace PrestonMarathonApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void amtr_runner_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.formHeading.Text = "Amateur Runner - Registration Form";
            reg.participantType.Text = "1";
            reg.Show();
            this.Close();
        }

        private void prof_runner_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.formHeading.Text = "Professional Runner - Registration Form";
            reg.participantType.Text = "2";
            reg.Show();
            this.Close();
        }

        private void volunteer_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.formHeading.Text = "Volunteer - Registration Form";
            reg.participantType.Text = "3";
            reg.Show();
            this.Close();
        }

        private void amateur_list_Click(object sender, RoutedEventArgs e)
        {
            AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
            amateurRunnerList.ShowDialog();
        }
    }
}
