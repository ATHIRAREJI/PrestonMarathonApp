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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        public void SubmitRegistration(object sender, RoutedEventArgs e)
        {
            MarathonParticipants marathonParticipants = new MarathonParticipants();
            marathonParticipants.particpiantFirstName = participantFirstName.Text;
            marathonParticipants.particpiantLastName = participantLastName.Text;
            marathonParticipants.particpiantEmail = participantEmail.Text;
            marathonParticipants.particpiantPhone  = participantPhone.Text;
            marathonParticipants.particpiantAddress = participantAddress.Text;

            marathonParticipants.addParticipant();

            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
