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
     * Interaction logic for AddSponsor.xaml
     */
    public partial class AddSponsor : Window
    {
        public AddSponsor()
        {
            InitializeComponent();
        }
        //Function to add amateur runner's sponsor details.
        private void addSponsorDetails(object sender, RoutedEventArgs e)
        {
            AmateurRunner amateurRunner = new AmateurRunner();
            amateurRunner.ParticipantId = Int32.Parse(participantId.Text);
            amateurRunner.SponsorName = sponsorName.Text;
            amateurRunner.SponsorshipAmount = Convert.ToDouble(Amount.Text);
            if(amateurRunner.addSponsorDetails() == 1)
            {
                MessageBox.Show("Sponsor details has been added successfully");
            }
        }

        //Function to load amateur runner listing window
        private void loadAmateurRunnerListing(object sender, RoutedEventArgs e)
        {
            AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
            amateurRunnerList.Show();
            this.Close();
        }
    }
}
