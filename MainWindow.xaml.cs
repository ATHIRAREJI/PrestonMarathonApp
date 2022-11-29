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
       
        //Amateur Runner functionality start
        private void amateurRunnerRegistration(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.formHeading.Text = "Amateur Runner - Registration Form";
            reg.participantType.Text = "1";
            reg.VolPanel.Visibility = Visibility.Hidden;
            reg.Show();
            this.Close();
        }

        private void getAmateurRunnerList(object sender, RoutedEventArgs e)
        {
            AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
            amateurRunnerList.Show();
            this.Close();
        }
        //Professional Runner functionality start
        private void professionalRunnerRegistration(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.formHeading.Text = "Professional Runner - Registration Form";
            reg.participantType.Text = "2";
            reg.VolPanel.Visibility = Visibility.Hidden;
            reg.Show();
            this.Close();
        }
        private void getProfessionalRunnerList(object sender, RoutedEventArgs e)
        {
            ProfessionalRunnerList professionalRunnerList = new ProfessionalRunnerList();
            professionalRunnerList.ShowDialog();
            this.Close();
        }

        //Volunteering Info Related Functions
        private void AddVoluteeringInfoPageLoad(object sender, RoutedEventArgs e)
        {
            AddVolunteeringInfo addVolunteeringInfo = new AddVolunteeringInfo();
            addVolunteeringInfo.Show();
            this.Close();
        }
        private void VolunteeringInfoListPageLoad(object sender, RoutedEventArgs e)
        {
            VolunteeringInfoList volunteeringInfo = new VolunteeringInfoList();
            volunteeringInfo.Show();
            this.Close();
        }

        //Volunteer Related Functions
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
            reg.participantType.Text = "3";
            reg.Show();
            this.Close();
        }
        private void loadVolunteerList(object sender, RoutedEventArgs e)
        {
           VolunteerList volunteerList = new VolunteerList();
           volunteerList.Show();
           this.Close();
        }
    }
}
