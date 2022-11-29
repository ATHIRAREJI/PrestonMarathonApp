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

            ParticipantCertificate participantCertificate = new ParticipantCertificate();
            participantCertificate.participantName.Text = participantName.ToUpper();
            participantCertificate.Show();
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(participantCertificate, "Window Printing.");
        }
        private void home_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
