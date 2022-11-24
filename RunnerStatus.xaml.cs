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
    /// Interaction logic for RunnerStatus.xaml
    /// </summary>
    public partial class RunnerStatus : Window
    {
        public RunnerStatus()
        {
            InitializeComponent();
        }

        private void updateRunnerStatus(object sender, RoutedEventArgs e)
        {
            
            if(participantType.Text == "1")
            {
                AmateurRunner amateurRunner = new AmateurRunner();
                amateurRunner.ParticipantId = Int32.Parse(participantId.Text);
                amateurRunner.ParticipationStatus = "Finished";
                amateurRunner.TimeFinished = TimeFinished.Text;

                if (amateurRunner.updateRunnerStatus() == 1)
                {
                    this.Close();
                    AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
                    amateurRunnerList.ShowDialog();
                }
            }
            else
            {
                ProfessionalRunner professionalRunner = new ProfessionalRunner();
                professionalRunner.ParticipantId = Int32.Parse(participantId.Text);
                professionalRunner.ParticipationStatus = "Finished";
                professionalRunner.TimeFinished = TimeFinished.Text;
                if (professionalRunner.updateRunnerStatus() == 1)
                {
                    this.Close();
                    ProfessionalRunnerList profRunnerList = new ProfessionalRunnerList();
                    profRunnerList.ShowDialog();
                }
            }
            
        }
    }
}
