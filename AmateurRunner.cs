using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace PrestonMarathonApp
{
    internal class AmateurRunner: MarathonParticipants
    {
        public string runnerCostume { get; set; }
        public string participationStatus { get; set; }
        public string runnerNo { get; set; }

        public string sponsorName { get; set; }

        public double sponsorshipAmount { get; set; }
        public List<AmateurRunner> getParticipantsBasicInfo()
        {
            List<AmateurRunner> AmateurRunnerInfoList = new List<AmateurRunner>();

            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string selectQuery = "SELECT id,first_name,last_name,costume,status from participant_info LEFT JOIN runner_costume ON " +
                "participant_info.id = runner_costume.runner_no";
            MySqlCommand cmd = new MySqlCommand(selectQuery);
            cmd.Connection = con;
            con.Open();
            MySqlDataReader runnerInfo = cmd.ExecuteReader();

            while (runnerInfo.Read())
            {
                AmateurRunner amateurRunnerinfo = new AmateurRunner();
                amateurRunnerinfo.participantId = (int)runnerInfo[0];
                amateurRunnerinfo.runnerNo = "Runner"+runnerInfo.GetString(0);
                amateurRunnerinfo.particpiantFirstName = runnerInfo.GetString(1);
                amateurRunnerinfo.particpiantLastName = runnerInfo.GetString(2);
                amateurRunnerinfo.participationStatus = runnerInfo.GetString(4);
                if (!DBNull.Value.Equals(runnerInfo["costume"]))
                {
                    amateurRunnerinfo.runnerCostume = runnerInfo.GetString(3);
                }
                else
                {
                    amateurRunnerinfo.runnerCostume = "Not added";
                }
                
               AmateurRunnerInfoList.Add(amateurRunnerinfo);
            }

            return AmateurRunnerInfoList;

        }
        public int AddCostume()
        {
            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string insertQuery = "INSERT INTO runner_costume(runner_no,costume) VALUES(" + participantId + ",'" + runnerCostume + "') ON DUPLICATE KEY UPDATE costume ='"+runnerCostume+"' ";
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
        public int updateRunnerStatus()
        {
            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string updateQuery = "UPDATE participant_info set status='Finished' where id= "+participantId;
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

        public int addSponsorDetails()
        {
            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string insertQuery = "INSERT INTO sponsors(runner_no,sponsor_name,amount) VALUES("+participantId+",'"+sponsorName+"',"+sponsorshipAmount+")";
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
        public List<AmateurRunner> getamateurRunner()
        {
            List<AmateurRunner> AmateurRunnerInfoList = new List<AmateurRunner>();

            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string getRunnerInfo = "SELECT id,first_name,last_name,costume,status,email,phone,address from participant_info LEFT JOIN runner_costume ON " +
                "participant_info.id = runner_costume.runner_no where participant_info.id ="+participantId;

            MySqlCommand cmd = new MySqlCommand(getRunnerInfo);
            cmd.Connection = con;
            con.Open();
            MySqlDataReader runnerInfo = cmd.ExecuteReader();

            while (runnerInfo.Read())
            {
                AmateurRunner amateurRunnerinfo = new AmateurRunner();
                amateurRunnerinfo.participantId = (int)runnerInfo[0];
                amateurRunnerinfo.runnerNo = "Runner" + runnerInfo.GetString(0);
                amateurRunnerinfo.particpiantFirstName = runnerInfo.GetString(1);
                amateurRunnerinfo.particpiantLastName = runnerInfo.GetString(2);
                amateurRunnerinfo.participationStatus = runnerInfo.GetString(4);
                if (!DBNull.Value.Equals(runnerInfo["costume"]))
                {
                    amateurRunnerinfo.runnerCostume = runnerInfo.GetString(3);
                }
                else
                {
                    amateurRunnerinfo.runnerCostume = "Not added";
                }
                amateurRunnerinfo.particpiantEmail = runnerInfo.GetString(5);
                amateurRunnerinfo.particpiantPhone = runnerInfo.GetString(6);
                amateurRunnerinfo.particpiantAddress = runnerInfo.GetString(7);

                AmateurRunnerInfoList.Add(amateurRunnerinfo);
            }

            return AmateurRunnerInfoList;

        }
    }
}
