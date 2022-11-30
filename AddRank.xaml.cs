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
    /// Interaction logic for AddRank.xaml
    /// </summary>
    public partial class AddRank : Window
    {
        public AddRank()
        {
            InitializeComponent();
        }
        private void AddRunnerRank(object sender, RoutedEventArgs e)
        {
            ProfessionalRunner professionalRunner = new ProfessionalRunner();
            professionalRunner.ParticipantId = Int32.Parse(participantId.Text);
            professionalRunner.RunnerRank = RunnerRank.Text;
            if(professionalRunner.AddRunnerRank() == 1)
            {
                ProfessionalRunnerList professionalRunnerList = new ProfessionalRunnerList();
                professionalRunnerList.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error occured. Please try again later");
            }
        }
    }
}
