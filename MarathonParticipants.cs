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
        public int participantId { get; set; }
        public string participantType { get; set; }
        public string particpiantFirstName { get; set; }
        public string particpiantLastName { get; set; }
        public string particpiantEmail { get; set; }
        public string particpiantPhone { get; set; }
        public string particpiantAddress { get; set; }

        public int addParticipant()
        {
            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string insertQuery = "INSERT INTO participant_info (participant_type,first_name,last_name,email,phone,address) VALUES " +
                "('"+participantType+ "','"+particpiantFirstName+"','"+particpiantLastName+"','"+particpiantEmail+"','"+particpiantPhone+"','"+particpiantAddress+"')";
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
    }
}
