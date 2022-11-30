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
    /// Interaction logic for VolunteerList.xaml
    /// </summary>
    public partial class VolunteerList : Window
    {
        public VolunteerList()
        {
            InitializeComponent();
            Volunteer volunteer = new Volunteer();
            VolunteerListGrid.ItemsSource = volunteer.getListOfParticipants();
        }
        private void generateCertificate(object sender, RoutedEventArgs e)
        {
            var ParticipantId = (((Button)sender).Tag).ToString();
            MarathonParticipants participants = new MarathonParticipants();
            participants.ParticipantId = Int32.Parse(ParticipantId);
            var participantName = participants.getParticipantName();

            VolunteerCertificate volunteerCertificate = new VolunteerCertificate();
            volunteerCertificate.participantName.Text = participantName.ToUpper();
            volunteerCertificate.Show();
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(volunteerCertificate, "Window Printing.");
        }
        private void home_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        private void viewDetail(object sender, RoutedEventArgs e)
        {
            var ParticipantId = (((Button)sender).Tag).ToString();
            Volunteer volunteer = new Volunteer();
            volunteer.ParticipantId = Int32.Parse(ParticipantId);
            List<Volunteer> volunteerInfo = volunteer.getParticipantInfo();
            VolunteerDetails volunteerDetails = new VolunteerDetails();
            foreach (Volunteer volInfo in volunteerInfo)
            {
                volunteerDetails.VolunteerNo.Text = volInfo.ParticipantId.ToString();
                volunteerDetails.FirstName.Text = volInfo.ParticpiantFirstName.ToString();
                volunteerDetails.LastName.Text = volInfo.ParticpiantLastName.ToString();
                volunteerDetails.Email.Text = volInfo.ParticpiantEmail.ToString();
                volunteerDetails.Phone.Text = volInfo.ParticpiantPhone.ToString();
                volunteerDetails.Address.Text = volInfo.ParticpiantAddress.ToString();
                volunteerDetails.VolType.Text = volInfo.VolunteeringType.ToString();
                volunteerDetails.StartTime.Text = volInfo.StartTime.ToString();
                volunteerDetails.EndTime.Text = volInfo.EndTime.ToString();
            }
            volunteerDetails.Show();
            this.Close();
        }


    }
}
