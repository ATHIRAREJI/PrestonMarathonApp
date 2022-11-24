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
using System.Data;

namespace PrestonMarathonApp
{
    /// <summary>
    /// Interaction logic for AmateurRunnerList.xaml
    /// </summary>
    public partial class AmateurRunnerList : Window
    {
        public AmateurRunnerList()
        {
            InitializeComponent();
            AmateurRunner amateurRunner = new AmateurRunner();
            AmaterListGrid.ItemsSource= amateurRunner.getListOfParticipants();
        }

        private void AddCostume(object sender, RoutedEventArgs e)
        {
            this.Close();
            var participantId = ((Button)sender).Tag;
            AddCostume costume = new AddCostume();
            costume.participantId.Text = participantId.ToString();
            costume.Show();
        }
        private void updateParticipantStatus(object sender, RoutedEventArgs e)
        {
            this.Close();
            RunnerStatus runnerStatus = new RunnerStatus();
            runnerStatus.participantId.Text = (((Button)sender).Tag).ToString();
            runnerStatus.participantType.Text = "1";
            runnerStatus.Show();
        }
        private void AddSponsor(object sender, RoutedEventArgs e)
        {
            var participantId = ((Button)sender).Tag;
            AddSponsor sponsor = new AddSponsor();
            sponsor.participantId.Text = participantId.ToString();
            sponsor.Show();
        }
        private void ViewDetails(object sender, RoutedEventArgs e)
        {
            var ParticipantId = (((Button)sender).Tag).ToString();
            AmateurRunner amateurRunner = new AmateurRunner();
            amateurRunner.ParticipantId = Int32.Parse(ParticipantId);
            List<AmateurRunner> RunnerInfo = amateurRunner.getParticipantInfo();
            AmateurRunnerDetails ViewDetails = new AmateurRunnerDetails();
           foreach (AmateurRunner info in RunnerInfo)
           {
                ViewDetails.RunnerCostume.Text = info.RunnerCostume.ToString();
                ViewDetails.Runnerno.Text = info.RunnerNo.ToString();
                ViewDetails.FirstName.Text = info.ParticpiantFirstName.ToString();
                ViewDetails.LastName.Text = info.ParticpiantLastName.ToString();
                ViewDetails.Status.Text = info.ParticipationStatus.ToString();
                ViewDetails.Email.Text = info.ParticpiantEmail.ToString();
                ViewDetails.Phone.Text = info.ParticpiantPhone.ToString();
                ViewDetails.Address.Text = info.ParticpiantAddress.ToString();
                ViewDetails.TimeFinished.Text = info.TimeFinished.ToString();
            }
            ViewDetails.SponsorshipGrid.ItemsSource = amateurRunner.getParticipantSponsorDetails();

            ViewDetails.Show();
        }
    }
}
