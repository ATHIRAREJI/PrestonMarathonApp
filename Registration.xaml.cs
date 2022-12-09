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
     * Interaction logic for Registration.xaml
     */
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        //Function to submit participant registration
        public void submitRegistration(object sender, RoutedEventArgs e)
        {
            int returnStatus;

            //Save amateur runner registartion details
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
            //Save professional runner registration details
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
            //Save volunteer registration details.
            else
            {
                Volunteer volunteer = new Volunteer();
                volunteer.ParticipantType = volType.Text;
                volunteer.ParticpiantFirstName = participantFirstName.Text;
                volunteer.ParticpiantLastName = participantLastName.Text;
                volunteer.ParticpiantEmail = participantEmail.Text;
                volunteer.ParticpiantPhone = participantPhone.Text;
                volunteer.ParticpiantAddress = participantAddress.Text;
                returnStatus = volunteer.addParticipant();
            }
       
            if (returnStatus == 1)
            {
                this.participantFirstName.Text = String.Empty;
                this.participantLastName.Text = String.Empty;
                this.participantEmail.Text = String.Empty;
                this.participantPhone.Text = String.Empty;
                this.participantAddress.Text = String.Empty;
                this.volType.SelectedIndex = 0;
                MessageBox.Show("Successfully Registered");
            }
            else
            {
                MessageBox.Show("Sorry. Internal error occured, Try again later");             
            }
            
        }

        //Function to load home window
        private void homeBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        //Function to load participant listing window
        private void loadListing(object sender, RoutedEventArgs e)
        {

            if (participantType.Text == "1")
            {
                AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
                amateurRunnerList.Show();
                this.Close();
            }
            else if(participantType.Text == "2")
            {
                ProfessionalRunnerList profRunnerList = new ProfessionalRunnerList();
                profRunnerList.Show();
                this.Close();
            }
            else
            {
                VolunteerList volunteerList = new VolunteerList();
                volunteerList.Show();
                this.Close();
            }
        }
    }
}
