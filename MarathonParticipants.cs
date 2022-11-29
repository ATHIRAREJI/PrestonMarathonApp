using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace PrestonMarathonApp
{

    internal class MarathonParticipants
    {
        public int ParticipantId { get; set; }
        public string ParticipantType { get; set; }
        public string ParticpiantFirstName { get; set; }
        public string ParticpiantLastName { get; set; }
        public string ParticpiantEmail { get; set; }
        public string ParticpiantPhone { get; set; }
        public string ParticpiantAddress { get; set; }

        public int addParticipant()
        {
            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string insertQuery = "INSERT INTO participant_info (participant_type,first_name,last_name,email,phone,address) VALUES " +
                "('"+ParticipantType+ "','"+ParticpiantFirstName+"','"+ParticpiantLastName+"','"+ParticpiantEmail+"','"+ParticpiantPhone+"','"+ParticpiantAddress+"')";
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
        public string getParticipantName()
        {
            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string participantInfo = "SELECT CONCAT(first_name,' ',last_name) as name from participant_info where id=" + ParticipantId;
            MySqlCommand cmd = new MySqlCommand(participantInfo);
            cmd.Connection = con;
            con.Open();
            MySqlDataReader pInfo = cmd.ExecuteReader();
            pInfo.Read();
            string name = pInfo["name"].ToString();
            return name;

        }
    }
}
