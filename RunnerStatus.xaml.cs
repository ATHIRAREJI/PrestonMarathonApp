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
    /**
     *  Interaction logic for RunnerStatus.xaml
     */
    public partial class RunnerStatus : Window
    {
        public RunnerStatus()
        {
            InitializeComponent();
        }

        //Function to update runner status into finished. This is a common function for both professional and amateur runner.
        private void updateRunnerStatus(object sender, RoutedEventArgs e)
        {
            
            if(participantType.Text == "1")
            {
                AmateurRunner amateurRunner = new AmateurRunner();
                amateurRunner.ParticipantId = Int32.Parse(participantId.Text);
                amateurRunner.ParticipationStatus = "Finished";
                amateurRunner.TimeFinished = TimeFinished.Text;

                if (amateurRunner.updateRunnerStatus() == 1)
                {
                    AmateurRunnerList amateurRunnerList = new AmateurRunnerList();
                    amateurRunnerList.Show();
                    this.Close();
                }
            }
            else
            {
                ProfessionalRunner professionalRunner = new ProfessionalRunner();
                professionalRunner.ParticipantId = Int32.Parse(participantId.Text);
                professionalRunner.ParticipationStatus = "Finished";
                professionalRunner.TimeFinished = TimeFinished.Text;
                if (professionalRunner.updateRunnerStatus() == 1)
                {
                    ProfessionalRunnerList profRunnerList = new ProfessionalRunnerList();
                    profRunnerList.Show();
                    this.Close();
                }
            }
            
        }
    }
}
