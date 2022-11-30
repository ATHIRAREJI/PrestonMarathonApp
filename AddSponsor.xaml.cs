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
    /// Interaction logic for AddSponsor.xaml
    /// </summary>
    public partial class AddSponsor : Window
    {
        public AddSponsor()
        {
            InitializeComponent();
        }

        private void sponsorBtn_Click(object sender, RoutedEventArgs e)
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
        private void amaterurListing(object sender, RoutedEventArgs e)
        {
            AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
            amateurRunnerList.Show();
            this.Close();
        }
    }
}
