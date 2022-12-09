using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace PrestonMarathonApp
{
    /**
     * AmateurRunner class consist of all property and methods related to the amateur runners. 
     * And also it inherits the properities and methods of it's parent class - MarathonParticipants. 
     */
    internal class AmateurRunner: MarathonParticipants, ICostume, IFetchParticipantInfo<AmateurRunner>, IRunnerStatus
    {
        public string RunnerCostume { get; set; }
        public string ParticipationStatus { get; set; }
        public string RunnerNo { get; set; }
        public string SponsorName { get; set; }
        public double SponsorshipAmount { get; set; }
        public string TimeFinished { get; set; }

        //Function to add amateur runner costume details
        public int addCostume()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string insertQuery = "INSERT INTO runner_costume(runner_no,costume) VALUES(" + ParticipantId + ",'" + RunnerCostume + "') ON DUPLICATE KEY UPDATE costume ='" + RunnerCostume + "' ";
                MySqlCommand cmd = new MySqlCommand(insertQuery);
                cmd.Connection = con;
                con.Open();
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            } 
            catch (MySqlException ex)
            {
                return ex.Number;
            }
        }
        //Function to update amateur runner status into finished. 
        public int updateRunnerStatus()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string updateQuery = "UPDATE participant_info set status='Finished',time_finished='" + TimeFinished + "' where id = " + ParticipantId;
                MySqlCommand cmd = new MySqlCommand(updateQuery);
                cmd.Connection = con;
                con.Open();
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            } 
            catch (MySqlException ex)
            {
                return ex.Number;
            }
        }
        
        //Function to add amateur runner sponsorship details.
        public int addSponsorDetails()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string insertQuery = "INSERT INTO sponsors(runner_no,sponsor_name,amount) VALUES(" + ParticipantId + ",'" + SponsorName + "'," + SponsorshipAmount + ")";
                MySqlCommand cmd = new MySqlCommand(insertQuery);
                cmd.Connection = con;
                con.Open();
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch(MySqlException ex)
            {
                return ex.Number;
            }
        }
        
        //Function to fetch a amateur runner's sponsorship details. 
        public List<AmateurRunner> getParticipantSponsorDetails()
        {
            List<AmateurRunner> AmateurRunnerInfoList = new List<AmateurRunner>();

            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string getRunnerInfo = "SELECT sponsor_name,amount from sponsors where runner_no =" + ParticipantId;

            MySqlCommand cmd = new MySqlCommand(getRunnerInfo);
            cmd.Connection = con;
            con.Open();
            MySqlDataReader runnerInfo = cmd.ExecuteReader();

            while (runnerInfo.Read())
            {
                AmateurRunner sponsorInfo = new AmateurRunner();
                sponsorInfo.SponsorName = runnerInfo.GetString(0);
                sponsorInfo.SponsorshipAmount = (Double)runnerInfo[1];
                AmateurRunnerInfoList.Add(sponsorInfo);
            }

            return AmateurRunnerInfoList;
        }
        
        //Function to fetch a single amateur runner details. This will return runner's basic info, status and costume details. 
        public List<AmateurRunner> getParticipantInfo()
        {
            List<AmateurRunner> AmateurRunnerInfoList = new List<AmateurRunner>();

            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string getRunnerInfo = "SELECT id,first_name,last_name,costume,status,email,phone,address,time_finished from participant_info LEFT JOIN runner_costume ON " +
                "participant_info.id = runner_costume.runner_no where participant_info.id ="+ParticipantId;

            MySqlCommand cmd = new MySqlCommand(getRunnerInfo);
            cmd.Connection = con;
            con.Open();
            MySqlDataReader runnerInfo = cmd.ExecuteReader();

            while (runnerInfo.Read())
            {
                AmateurRunner amateurRunnerinfo = new AmateurRunner();
                amateurRunnerinfo.ParticipantId = (int)runnerInfo[0];
                amateurRunnerinfo.RunnerNo = "Runner" + runnerInfo.GetString(0);
                amateurRunnerinfo.ParticpiantFirstName = runnerInfo.GetString(1);
                amateurRunnerinfo.ParticpiantLastName = runnerInfo.GetString(2);
                amateurRunnerinfo.ParticipationStatus = runnerInfo.GetString(4);
                if (!DBNull.Value.Equals(runnerInfo["costume"]))
                {
                    amateurRunnerinfo.RunnerCostume = runnerInfo.GetString(3);
                }
                else
                {
                    amateurRunnerinfo.RunnerCostume = "Not added";
                }
                amateurRunnerinfo.ParticpiantEmail = runnerInfo.GetString(5);
                amateurRunnerinfo.ParticpiantPhone = runnerInfo.GetString(6);
                amateurRunnerinfo.ParticpiantAddress = runnerInfo.GetString(7);
                if (!DBNull.Value.Equals(runnerInfo["time_finished"]))
                {
                    amateurRunnerinfo.TimeFinished = runnerInfo.GetString(8);
                }
                else
                {
                    amateurRunnerinfo.TimeFinished = "Will be added only after the Marathon";
                }

                AmateurRunnerInfoList.Add(amateurRunnerinfo);
            }

            return AmateurRunnerInfoList;

        }
        
        //Function to get all amateur runner basic details for the listing window. 
        public List<AmateurRunner> getListOfParticipants()
        {
            List<AmateurRunner> AmateurRunnerInfoList = new List<AmateurRunner>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string selectQuery = "SELECT id,first_name,last_name,costume,status from participant_info LEFT JOIN runner_costume ON " +
                    "participant_info.id = runner_costume.runner_no where participant_info.participant_type='1' order by participant_info.id desc";
                MySqlCommand cmd = new MySqlCommand(selectQuery);
                cmd.Connection = con;
                con.Open();
                MySqlDataReader runnerInfo = cmd.ExecuteReader();

                while (runnerInfo.Read())
                {
                    AmateurRunner amateurRunnerinfo = new AmateurRunner();
                    amateurRunnerinfo.ParticipantId = (int)runnerInfo[0];
                    amateurRunnerinfo.RunnerNo = "Runner" + runnerInfo.GetString(0);
                    amateurRunnerinfo.ParticpiantFirstName = runnerInfo.GetString(1);
                    amateurRunnerinfo.ParticpiantLastName = runnerInfo.GetString(2);
                    amateurRunnerinfo.ParticipationStatus = runnerInfo.GetString(4);
                    if (!DBNull.Value.Equals(runnerInfo["costume"]))
                    {
                        amateurRunnerinfo.RunnerCostume = runnerInfo.GetString(3);
                    }
                    else
                    {
                        amateurRunnerinfo.RunnerCostume = "Not added";
                    }

                    AmateurRunnerInfoList.Add(amateurRunnerinfo);
                }

             return AmateurRunnerInfoList;
            } 
            catch (MySqlException ex)
            {
                return AmateurRunnerInfoList;
            }
        }
    }
}
