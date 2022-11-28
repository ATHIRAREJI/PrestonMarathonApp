﻿using System;
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
    /// Interaction logic for VolunteeringInfoList.xaml
    /// </summary>
    public partial class VolunteeringInfoList : Window
    {
        public VolunteeringInfoList()
        {
            InitializeComponent();
            Volunteer volunteer = new Volunteer();
            VolunteeringInfoGrid.ItemsSource = volunteer.getListOfParticipants();
        }
    }
}
