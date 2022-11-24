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
    }
}
