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
     * Interaction logic for ProfessionalRunnerDetails.xaml
     */
    public partial class ProfessionalRunnerDetails : Window
    {
        public ProfessionalRunnerDetails()
        {
            InitializeComponent();
        }

        //Function to load professional runner listing window
        private void backtoList(object sender, RoutedEventArgs e)
        {
           ProfessionalRunnerList professionalRunnerList = new ProfessionalRunnerList();
           professionalRunnerList.Show();
           this.Close();
        }
    }
}
