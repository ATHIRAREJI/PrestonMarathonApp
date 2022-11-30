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
    /// Interaction logic for VolunteerDetails.xaml
    /// </summary>
    public partial class VolunteerDetails : Window
    {
        public VolunteerDetails()
        {
            InitializeComponent();
        }
        private void backtoList(object sender, RoutedEventArgs e)
        {
            VolunteerList volunteerList = new VolunteerList();
            volunteerList.Show();
            this.Close();
        }
    }
}
