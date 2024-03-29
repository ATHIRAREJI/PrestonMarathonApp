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
using System.Data;
using System.Printing;

namespace PrestonMarathonApp
{
    /**
     * Interaction logic for AmateurRunnerList.xaml
     */
    public partial class AmateurRunnerList : Window
    {
        public AmateurRunnerList()
        {
            InitializeComponent();
            AmateurRunner amateurRunner = new AmateurRunner();
            AmaterListGrid.ItemsSource= amateurRunner.getListOfParticipants();
        }

        //Function to load AddCostume window
        private void addCostume(object sender, RoutedEventArgs e)
        {
            var participantId = ((Button)sender).Tag;
            AddCostume costume = new AddCostume();
            costume.participantId.Text = participantId.ToString();
            costume.Show();
            this.Close();
        }

        //Function to update amateur runner's status to finished
        private void updateParticipantStatus(object sender, RoutedEventArgs e)
        {
            RunnerStatus runnerStatus = new RunnerStatus();
            runnerStatus.participantId.Text = (((Button)sender).Tag).ToString();
            runnerStatus.participantType.Text = "1";
            runnerStatus.Show();
            this.Close();
        }

        //Function to load Addsponsor window
        private void addSponsor(object sender, RoutedEventArgs e)
        {
            var participantId = ((Button)sender).Tag;
            AddSponsor sponsor = new AddSponsor();
            sponsor.participantId.Text = participantId.ToString();
            sponsor.Show();
            this.Close();
        }

        //Function to load amateur runner details window
        private void viewDetails(object sender, RoutedEventArgs e)
        {
            var ParticipantId = (((Button)sender).Tag).ToString();
            AmateurRunner amateurRunner = new AmateurRunner();
            amateurRunner.ParticipantId = Int32.Parse(ParticipantId);
            List<AmateurRunner> RunnerInfo = amateurRunner.getParticipantInfo();
            AmateurRunnerDetails ViewDetails = new AmateurRunnerDetails();
           foreach (AmateurRunner info in RunnerInfo)
           {
                ViewDetails.RunnerCostume.Text = info.RunnerCostume.ToString();
                ViewDetails.Runnerno.Text = info.RunnerNo.ToString();
                ViewDetails.FirstName.Text = info.ParticpiantFirstName.ToString();
                ViewDetails.LastName.Text = info.ParticpiantLastName.ToString();
                ViewDetails.Status.Text = info.ParticipationStatus.ToString();
                ViewDetails.Email.Text = info.ParticpiantEmail.ToString();
                ViewDetails.Phone.Text = info.ParticpiantPhone.ToString();
                ViewDetails.Address.Text = info.ParticpiantAddress.ToString();
                ViewDetails.TimeFinished.Text = info.TimeFinished.ToString();
            }
            ViewDetails.SponsorshipGrid.ItemsSource = amateurRunner.getParticipantSponsorDetails();

            ViewDetails.Show();
            this.Close();
        }
        //Function to load certificate window and functionality to save certificate automatically. 
        private void generateCertificate(object sender, RoutedEventArgs e)
        {
            var ParticipantId = (((Button)sender).Tag).ToString();
            MarathonParticipants participants = new MarathonParticipants();
            participants.ParticipantId = Int32.Parse(ParticipantId);
            var participantName = participants.getParticipantName();
            
            ParticipantCertificate participantCertificate = new ParticipantCertificate();
            participantCertificate.participantName.Text = participantName.ToUpper();
            participantCertificate.Show();
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(participantCertificate, "Window Printing.");
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
