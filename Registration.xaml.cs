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
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        public void SubmitRegistration(object sender, RoutedEventArgs e)
        {
            int returnStatus;
            if(participantType.Text == "1")
            {
                AmateurRunner amateurRunner = new AmateurRunner();
                amateurRunner.ParticipantType = participantType.Text;
                amateurRunner.ParticpiantFirstName = participantFirstName.Text;
                amateurRunner.ParticpiantLastName = participantLastName.Text;
                amateurRunner.ParticpiantEmail = participantEmail.Text;
                amateurRunner.ParticpiantPhone = participantPhone.Text;
                amateurRunner.ParticpiantAddress = participantAddress.Text;
                returnStatus = amateurRunner.addParticipant();
            }
            else if(participantType.Text == "2")
            {
                ProfessionalRunner profRunner = new ProfessionalRunner();
                profRunner.ParticipantType = participantType.Text;
                profRunner.ParticpiantFirstName = participantFirstName.Text;
                profRunner.ParticpiantLastName = participantLastName.Text;
                profRunner.ParticpiantEmail = participantEmail.Text;
                profRunner.ParticpiantPhone = participantPhone.Text;
                profRunner.ParticpiantAddress = participantAddress.Text;
                returnStatus = profRunner.addParticipant();
            }
            else
            {
                Volunteer volunteer = new Volunteer();
                volunteer.ParticipantType = participantType.Text;
                volunteer.ParticpiantFirstName = participantFirstName.Text;
                volunteer.ParticpiantLastName = participantLastName.Text;
                volunteer.ParticpiantEmail = participantEmail.Text;
                volunteer.ParticpiantPhone = participantPhone.Text;
                volunteer.ParticpiantAddress = participantAddress.Text;
                returnStatus = volunteer.addParticipant();
            }
            
            if (returnStatus == 1)
            {
                MessageBox.Show("Successfully Registered");
                this.Show();
            }
            else
            {
                MessageBox.Show("Sorry. Internal error occured, Try again later");
                this.Show();               
            }
              
        }

        private void home_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void go_to_list_Click(object sender, RoutedEventArgs e)
        {

            if (participantType.Text == "1")
            {
                AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
                amateurRunnerList.Show();
            }
            else if(participantType.Text == "2")
            {
                AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
                amateurRunnerList.Show();
            }
            else
            {
                AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
                amateurRunnerList.Show();
            }
        }
    }
}
