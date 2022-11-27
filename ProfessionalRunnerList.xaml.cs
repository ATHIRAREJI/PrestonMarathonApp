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
    public partial class ProfessionalRunnerList : Window
    {
        public ProfessionalRunnerList()
        {
            InitializeComponent();
            ProfessionalRunner professionalRunner = new ProfessionalRunner();
            ProfessionalRunnerListGrid.ItemsSource = professionalRunner.getListOfParticipants();
        }

        private void updateParticipantStatus(object sender, RoutedEventArgs e)
        {
            this.Close();
            RunnerStatus runnerStatus = new RunnerStatus();
            runnerStatus.participantId.Text = (((Button)sender).Tag).ToString();
            runnerStatus.participantType.Text = "2";
            runnerStatus.Show();
        }
        private void ViewDetails(object sender, RoutedEventArgs e)
        {
            var ParticipantId = (((Button)sender).Tag).ToString();
            ProfessionalRunner professionalRunner = new ProfessionalRunner();
            professionalRunner.ParticipantId = Int32.Parse(ParticipantId);
            List<ProfessionalRunner> RunnerInfo = professionalRunner.getParticipantInfo();
            ProfessionalRunnerDetails professionalRunnerDetails = new ProfessionalRunnerDetails();

            foreach (ProfessionalRunner info in RunnerInfo)
            {
                professionalRunnerDetails.RunnerRank.Text = info.RunnerNo.ToString();
                professionalRunnerDetails.FirstName.Text = info.ParticpiantFirstName.ToString();
                professionalRunnerDetails.LastName.Text = info.ParticpiantLastName.ToString();
                professionalRunnerDetails.Status.Text = info.ParticipationStatus.ToString();
                professionalRunnerDetails.Email.Text = info.ParticpiantEmail.ToString();
                professionalRunnerDetails.Phone.Text = info.ParticpiantPhone.ToString();
                professionalRunnerDetails.Address.Text = info.ParticpiantAddress.ToString();
                professionalRunnerDetails.TimeFinished.Text = info.TimeFinished.ToString();
            }
            
            professionalRunnerDetails.Show();
        }
        private void AddRankPageLoad(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddRank addRank = new AddRank();
            addRank.participantId.Text = (((Button)sender).Tag).ToString();
            addRank.Show();
        }
    }
}
