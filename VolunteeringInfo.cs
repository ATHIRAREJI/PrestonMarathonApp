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
     * Participant parent class and it consist of all property and methods common for amateur runner, professional
     * runner and volunteer.
     */
    internal class VolunteeringInfo: IVolunteer
    {
        public int VolTypeId { get; set; }
        public string VolunteeringType { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; } 

        //Function to add volunteering Info details
        public int addVolunteeringInfo()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string insertQuery = "INSERT INTO volunteer_info(volunteering_type,start_time,end_time) VALUES('" + VolunteeringType + "','" + StartTime + "','" + EndTime + "')";
                MySqlCommand cmd = new MySqlCommand(insertQuery);
                cmd.Connection = con;
                con.Open();
                int status = cmd.ExecuteNonQuery();
                return status;
            }
            catch(MySqlException ex)
            {
                return ex.Number;
            }
        }

        //Function to fetch volunteering info details for the listing window
        public List<VolunteeringInfo> getVolunteeringInfo()
        {
            List<VolunteeringInfo> VolunteeringInfoList = new List<VolunteeringInfo>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string getVolunteerInfo = "SELECT *from volunteer_info";

                MySqlCommand cmd = new MySqlCommand(getVolunteerInfo);
                cmd.Connection = con;
                con.Open();
                MySqlDataReader volunteerInfo = cmd.ExecuteReader();

                while (volunteerInfo.Read())
                {
                    VolunteeringInfo volInfo = new VolunteeringInfo();
                    volInfo.VolTypeId = (int)volunteerInfo[0];
                    volInfo.VolunteeringType = volunteerInfo.GetString(1);
                    volInfo.StartTime = volunteerInfo.GetString(2);
                    volInfo.EndTime = volunteerInfo.GetString(3);
                    VolunteeringInfoList.Add(volInfo);
                }
                return VolunteeringInfoList;
            }
            catch (MySqlException ex)
            {
                return VolunteeringInfoList;
            }
        }
    }
}
