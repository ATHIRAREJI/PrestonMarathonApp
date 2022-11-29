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
    /// Interaction logic for AddCostume.xaml
    /// </summary>
    public partial class AddCostume : Window
    {
        public AddCostume()
        {
            InitializeComponent();
        }

        private void AddCostumeDetails_Click(object sender, RoutedEventArgs e)
        {
            AmateurRunner runner = new AmateurRunner();
            runner.ParticipantId = Int32.Parse(participantId.Text);
            runner.RunnerCostume = costumeDetails.Text;

            if (runner.AddCostume() ==  1)
            {
                AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
                amateurRunnerList.ShowDialog();
                this.Close();
            }
            
        }
    }
}
