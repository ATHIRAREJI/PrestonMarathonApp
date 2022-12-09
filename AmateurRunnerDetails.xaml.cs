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
     * Interaction logic for AmateurRunnerDetails.xaml
     */
    public partial class AmateurRunnerDetails : Window
    {
        public AmateurRunnerDetails()
        {
            InitializeComponent();
        }
        //Function to load amateur runner's listing page
        private void loadAmaterurRunnerListing(object sender, RoutedEventArgs e)
        {
            AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
            amateurRunnerList.Show();
            this.Close();
        }
            
    }
}
