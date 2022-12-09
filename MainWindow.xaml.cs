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
    /**
     * Mainwindow of PrestonMarathonApp
     * Interaction logic of MainWindow.xaml
     */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Load amateur runner registartion page.
        private void amateurRunnerRegistration(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.formHeading.Text = "Amateur Runner - Registration Form";
            
            //Type of amateur runner is 1 and it will set into a text box in the regsitraton page to identify the participant type. 
            reg.participantType.Text = "1";
            reg.VolPanel.Visibility = Visibility.Hidden;
            reg.Show();
            this.Close();
        }

        //Load amateur runner listing window
        private void getAmateurRunnerList(object sender, RoutedEventArgs e)
        {
            AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
            amateurRunnerList.Show();
            this.Close();
        }

        //Load professional runner registration window
        private void professionalRunnerRegistration(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.formHeading.Text = "Professional Runner - Registration Form";

            //Type of professional runner is 2 and it will set into a text box in the regsitraton page to identify the participant type. 
            reg.participantType.Text = "2";
            reg.VolPanel.Visibility = Visibility.Hidden;
            reg.Show();
            this.Close();
        }

        //Load professional runner listing window
        private void getProfessionalRunnerList(object sender, RoutedEventArgs e)
        {
            ProfessionalRunnerList professionalRunnerList = new ProfessionalRunnerList();
            professionalRunnerList.ShowDialog();
            this.Close();
        }

        //Load new volunteering info addition page
        private void addVoluteeringInfoPageLoad(object sender, RoutedEventArgs e)
        {
            AddVolunteeringInfo addVolunteeringInfo = new AddVolunteeringInfo();
            addVolunteeringInfo.Show();
            this.Close();
        }

        //Load lounteering info listing window
        private void volunteeringInfoListPageLoad(object sender, RoutedEventArgs e)
        {
            VolunteeringInfoList volunteeringInfo = new VolunteeringInfoList();
            volunteeringInfo.Show();
            this.Close();
        }

        //Load volunteer registration window
        private void volunteerRegistration(object sender, RoutedEventArgs e)
        {
            VolunteeringInfo volunteeringInfo = new VolunteeringInfo();
            List<VolunteeringInfo> infoList = volunteeringInfo.getVolunteeringInfo();
            Registration reg = new Registration();
            foreach (VolunteeringInfo volunteeringInfoItem in infoList)
            {
                reg.volType.Items.Add(volunteeringInfoItem.VolunteeringType);
            }
            reg.formHeading.Text = "Volunteer - Registration Form";

            //Type of professional runner is 3 and it will set into a text box in the regsitraton page to identify the participant type.
            reg.participantType.Text = "3";
            reg.Show();
            this.Close();
        }
        
        //Load volunteer listing page
        private void loadVolunteerList(object sender, RoutedEventArgs e)
        {
           VolunteerList volunteerList = new VolunteerList();
           volunteerList.Show();
           this.Close();
        }
    }
}
