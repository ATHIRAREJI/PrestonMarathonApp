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
     * Interaction logic for ProfessionalRunnerList.xaml
     */
    public partial class ProfessionalRunnerList : Window
    {
        public ProfessionalRunnerList()
        {
            InitializeComponent();
            ProfessionalRunner professionalRunner = new ProfessionalRunner();
            ProfessionalRunnerListGrid.ItemsSource = professionalRunner.getListOfParticipants();
        }

        //Function to upload professional runner status to finished.
        private void updateParticipantStatus(object sender, RoutedEventArgs e)
        {
            RunnerStatus runnerStatus = new RunnerStatus();
            runnerStatus.participantId.Text = (((Button)sender).Tag).ToString();
            runnerStatus.participantType.Text = "2";
            runnerStatus.Show();
            this.Close();
        }

        //Function to load professional runner detail view window.  
        private void viewDetails(object sender, RoutedEventArgs e)
        {
            var ParticipantId = (((Button)sender).Tag).ToString();
            ProfessionalRunner professionalRunner = new ProfessionalRunner();
            professionalRunner.ParticipantId = Int32.Parse(ParticipantId);
            List<ProfessionalRunner> RunnerInfo = professionalRunner.getParticipantInfo();
            ProfessionalRunnerDetails professionalRunnerDetails = new ProfessionalRunnerDetails();

            foreach (ProfessionalRunner info in RunnerInfo)
            {
                professionalRunnerDetails.Runnerno.Text = info.RunnerNo.ToString();
                professionalRunnerDetails.RunnerRank.Text = info.RunnerRank.ToString();
                professionalRunnerDetails.FirstName.Text = info.ParticpiantFirstName.ToString();
                professionalRunnerDetails.LastName.Text = info.ParticpiantLastName.ToString();
                professionalRunnerDetails.Status.Text = info.ParticipationStatus.ToString();
                professionalRunnerDetails.Email.Text = info.ParticpiantEmail.ToString();
                professionalRunnerDetails.Phone.Text = info.ParticpiantPhone.ToString();
                professionalRunnerDetails.Address.Text = info.ParticpiantAddress.ToString();
                professionalRunnerDetails.TimeFinished.Text = info.TimeFinished.ToString();
            }
            professionalRunnerDetails.Show();
            this.Close();
        }

        //Function to load addRank window. 
        private void addRankPageLoad(object sender, RoutedEventArgs e)
        {
            AddRank addRank = new AddRank();
            addRank.participantId.Text = (((Button)sender).Tag).ToString();
            addRank.Show();
            this.Close();
        }

        //Function to load and generate professional certificate. 
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

        //Function to load homw window.
        private void homeBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
