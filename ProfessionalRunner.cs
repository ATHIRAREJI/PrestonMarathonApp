using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace PrestonMarathonApp
{
    internal class ProfessionalRunner:MarathonParticipants, IFetchParticipantInfo<ProfessionalRunner>
    {

        public string RunnerRank { get; set; }
        public string RunnerNo { get; set; }
        public string ParticipationStatus { get; set; }
        public string TimeFinished { get; set; }

        public int updateRunnerStatus()
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
        public List<ProfessionalRunner> getParticipantInfo()
        {
            List<ProfessionalRunner> ProfessionalRunnerInfoList = new List<ProfessionalRunner>();

            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string getRunnerInfo = "SELECT id,first_name,last_name,runner_rank,email,phone,address from participant_info LEFT JOIN runner_costume ON " +
                "participant_info.id = runner_costume.runner_no where participant_info.participant_type='2' AND participant_info.id =" + ParticipantId;

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

                ProfessionalRunnerInfoList.Add(profRunnerinfo);
            }

            return ProfessionalRunnerInfoList;

        }
        public List<ProfessionalRunner> getListOfParticipants()
        {
            List<ProfessionalRunner> ProfessionalRunnerInfoList = new List<ProfessionalRunner>();

            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string selectQuery = "SELECT id,first_name,last_name,status,runner_rank from participant_info LEFT JOIN runner_rank ON " +
                "participant_info.id = runner_rank.runner_no where participant_info.participant_type='2'";
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
                }
                else
                {
                    profRunnerinfo.RunnerRank = "Not added";
                }

                ProfessionalRunnerInfoList.Add(profRunnerinfo);
            }

            return ProfessionalRunnerInfoList;

        }

    }
}
