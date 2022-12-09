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

namespace PrestonMarathonApp
{   
    /**
     * Interaction logic for AddVolunteeringInfo.xaml
     */
    public partial class AddVolunteeringInfo : Window
    {
        public AddVolunteeringInfo()
        {
            InitializeComponent();
        }

        //Function to add volunteering info details
        private void addVolunteeringInfo(object sender, RoutedEventArgs e)
        {
            VolunteeringInfo volunteeringInfo = new VolunteeringInfo();
            volunteeringInfo.VolunteeringType = VolunteeringType.Text;
            volunteeringInfo.StartTime = StartTime.Text;
            volunteeringInfo.EndTime = EndTime.Text;
            if(volunteeringInfo.addVolunteeringInfo() == 1)
            {
                this.VolunteeringType.Text = String.Empty;
                this.StartTime.SelectedIndex = 0;
                this.EndTime.SelectedIndex= 0;   

                MessageBox.Show("Volunteering info added successfully");
            }
            else
            {
                MessageBox.Show("Sorry. Internal error occured, Try again later");
            }
        }

        //Function to load home window
        private void backToHomeBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();   
            mainWindow.Show();
            this.Close();
        }
    }
}
