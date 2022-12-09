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
     * Interaction logic for VolunteeringInfoList.xaml
     */
    public partial class VolunteeringInfoList : Window
    {
        public VolunteeringInfoList()
        {
            InitializeComponent();
            VolunteeringInfo volunteerinfo = new VolunteeringInfo();
            VolunteeringInfoGrid.ItemsSource = volunteerinfo.getVolunteeringInfo();
        }

        //Function to load home window
        private void homeBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
