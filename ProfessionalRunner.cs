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
    * Professional Runner class consist of all property and methods related to the professional runners. 
    * And also it inherits the properities and methods of it's parent class - MarathonParticipants. 
    */
    internal class ProfessionalRunner:MarathonParticipants, IFetchParticipantInfo<ProfessionalRunner>
    {

        public string RunnerRank { get; set; }
        public string RunnerNo { get; set; }
        public string ParticipationStatus { get; set; }
        public string TimeFinished { get; set; }
        public bool IsRankAdded { get; set; }

        //Function to update professional runner status into finished.
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
            catch(MySqlException ex)
            {
                return ex.Number;
            }
        }

        //Function to fetch a single amateur runner details. This will return runner's basic info, status and rank details.
        public List<ProfessionalRunner> getParticipantInfo()
        {
            List<ProfessionalRunner> ProfessionalRunnerInfoList = new List<ProfessionalRunner>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string getRunnerInfo = "SELECT id,first_name,last_name,runner_rank,status,email,phone,address,time_finished from participant_info LEFT JOIN runner_world_rank ON " +
                    "participant_info.id = runner_world_rank.runner_no where participant_info.participant_type='2' AND participant_info.id =" + ParticipantId;

                MySqlCommand cmd = new MySqlCommand(getRunnerInfo);
                cmd.Connection = con;
                con.Open();
                MySqlDataReader runnerInfo = cmd.ExecuteReader();

                while (runnerInfo.Read())
                {
                    ProfessionalRunner profRunnerinfo = new ProfessionalRunner();
                    profRunnerinfo.ParticipantId = (int)runnerInfo[0];
                    profRunnerinfo.RunnerNo = "Runner" + runnerInfo.GetString(0);
                    profRunnerinfo.ParticpiantFirstName = runnerInfo.GetString(1);
                    profRunnerinfo.ParticpiantLastName = runnerInfo.GetString(2);
                    profRunnerinfo.ParticipationStatus = runnerInfo.GetString(4);
                    if (!DBNull.Value.Equals(runnerInfo["runner_rank"]))
                    {
                        profRunnerinfo.RunnerRank = runnerInfo.GetString(3);
                    }
                    else
                    {
                        profRunnerinfo.RunnerRank = "Not added";
                    }
                    profRunnerinfo.ParticpiantEmail = runnerInfo.GetString(5);
                    profRunnerinfo.ParticpiantPhone = runnerInfo.GetString(6);
                    profRunnerinfo.ParticpiantAddress = runnerInfo.GetString(7);

                    if (!DBNull.Value.Equals(runnerInfo["time_finished"]))
                    {
                        profRunnerinfo.TimeFinished = runnerInfo.GetString(8);
                    }
                    else
                    {
                        profRunnerinfo.TimeFinished = "Will be added only after the Marathon";
                    }
                    ProfessionalRunnerInfoList.Add(profRunnerinfo);
                }

                return ProfessionalRunnerInfoList;
            }
            catch(MySqlException ex)
            {
                return ProfessionalRunnerInfoList;
            }

        }

        //Function to get all professional runner basic details for the listing window.
        public List<ProfessionalRunner> getListOfParticipants()
        {
            List<ProfessionalRunner> ProfessionalRunnerInfoList = new List<ProfessionalRunner>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string selectQuery = "SELECT id,first_name,last_name,status,runner_rank from participant_info LEFT JOIN runner_rank ON " +
                    "participant_info.id = runner_rank.runner_no where participant_info.participant_type='2' order by participant_info.id desc";
                MySqlCommand cmd = new MySqlCommand(selectQuery);
                cmd.Connection = con;
                con.Open();
                MySqlDataReader runnerInfo = cmd.ExecuteReader();

                while (runnerInfo.Read())
                {
                    ProfessionalRunner profRunnerinfo = new ProfessionalRunner();
                    profRunnerinfo.ParticipantId = (int)runnerInfo[0];
                    profRunnerinfo.RunnerNo = "Runner" + runnerInfo.GetString(0);
                    profRunnerinfo.ParticpiantFirstName = runnerInfo.GetString(1);
                    profRunnerinfo.ParticpiantLastName = runnerInfo.GetString(2);
                    profRunnerinfo.ParticipationStatus = runnerInfo.GetString(3);
                    if (!DBNull.Value.Equals(runnerInfo["runner_rank"]))
                    {
                        profRunnerinfo.RunnerRank = runnerInfo.GetString(4);
                        profRunnerinfo.IsRankAdded = true;
                    }
                    else
                    {
                        profRunnerinfo.IsRankAdded = false;
                        profRunnerinfo.RunnerRank = "Not added";
                    }

                    ProfessionalRunnerInfoList.Add(profRunnerinfo);
                }

                return ProfessionalRunnerInfoList;
            }
            catch(MySqlException ex)
            {
                return ProfessionalRunnerInfoList;
            }

        }

        //Function to add professional runner rank
        public int addRunnerRank()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string insertQuery = "INSERT INTO runner_rank(runner_no,runner_rank) VALUES(" + ParticipantId + ",'" + RunnerRank + "') ON DUPLICATE KEY UPDATE runner_rank ='" + RunnerRank + "' ";
                MySqlCommand cmd = new MySqlCommand(insertQuery);
                cmd.Connection = con;
                con.Open();
                int status = cmd.ExecuteNonQuery();
                return status;
            }
            catch (MySqlException ex)
            {
                return ex.Number;
            }
        }

    }
}
