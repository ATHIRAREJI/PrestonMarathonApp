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
            AmaterListGrid.ItemsSource= amateurRunner.getParticipantsBasicInfo();
        }

        private void AddCostume(object sender, RoutedEventArgs e)
        {
            var participantId = ((Button)sender).Tag;
            AddCostume costume = new AddCostume();
            costume.participantId.Text = participantId.ToString();
            costume.Show();
        }
        private void update_particpant_status(object sender, RoutedEventArgs e)
        {
            var participantId = (((Button)sender).Tag).ToString();
            AmateurRunner amateurRunner = new AmateurRunner();
            amateurRunner.participantId = Int32.Parse(participantId);
            if(amateurRunner.updateRunnerStatus() == 1)
            {
                //AmaterListGrid.Items.Refresh();
                AmaterListGrid.ItemsSource = amateurRunner.getParticipantsBasicInfo();
            }
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
            var participantId = (((Button)sender).Tag).ToString();
            AmateurRunner amateurRunner = new AmateurRunner();
            amateurRunner.participantId = Int32.Parse(participantId);
            List<AmateurRunner> RunnerInfo = amateurRunner.getamateurRunner();
            AmateurRunnerDetails ViewDetails = new AmateurRunnerDetails();
            foreach (AmateurRunner info in RunnerInfo)
            {
                ViewDetails.Runnerno.Text = info.participantId.ToString();
            }
            ViewDetails.Show();
        }
    }
}
