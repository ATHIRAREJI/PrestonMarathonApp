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
     * Volunteer class consist of all property and methods related to the volunteer participant. 
     * And also it inherits the properities and methods of it's parent class - MarathonParticipants. 
     */
    internal class Volunteer:MarathonParticipants, IVolunteer, IFetchParticipantInfo<Volunteer>
    {
        public int VolTypeId { get; set; }
        public string VolunteeringType { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        //Function to fetch a single volunteer details. This will return volunteer's basic info.
        public List<Volunteer> getParticipantInfo()
        {
            List<Volunteer> VolunteerInfoList = new List<Volunteer>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string getRunnerInfo = "SELECT participant_info.id,first_name,last_name,email,phone,address,participant_info.participant_type,start_time,end_time from participant_info LEFT JOIN volunteer_info ON " +
                    "participant_info.participant_type = volunteer_info.volunteering_type where participant_info.participant_type not in ('1','2') AND participant_info.id =" + ParticipantId;

                MySqlCommand cmd = new MySqlCommand(getRunnerInfo);
                cmd.Connection = con;
                con.Open();
                MySqlDataReader volInfo = cmd.ExecuteReader();

                while (volInfo.Read())
                {
                    Volunteer volunteerinfo = new Volunteer();
                    volunteerinfo.ParticipantId = (int)volInfo[0];
                    volunteerinfo.ParticpiantFirstName = volInfo.GetString(1);
                    volunteerinfo.ParticpiantLastName = volInfo.GetString(2);
                    volunteerinfo.ParticpiantEmail = volInfo.GetString(3);
                    volunteerinfo.ParticpiantPhone = volInfo.GetString(4);
                    volunteerinfo.ParticpiantAddress = volInfo.GetString(5);
                    volunteerinfo.VolunteeringType = volInfo.GetString(6);
                    volunteerinfo.StartTime = volInfo.GetString(7);
                    volunteerinfo.EndTime = volInfo.GetString(8);
                    VolunteerInfoList.Add(volunteerinfo);
                }

                return VolunteerInfoList;
            }
            catch(MySqlException ex)
            {
                return VolunteerInfoList;
            }

        }

        //Function to get all volunteers basic details for the listing window.
        public List<Volunteer> getListOfParticipants()
        {
            List<Volunteer> VolunteerInfoList = new List<Volunteer>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string selectQuery = "SELECT id,first_name,last_name,participant_type from participant_info where participant_info.participant_type not in ('1','2')";
                MySqlCommand cmd = new MySqlCommand(selectQuery);
                cmd.Connection = con;
                con.Open();
                MySqlDataReader volInfo = cmd.ExecuteReader();

                while (volInfo.Read())
                {
                    Volunteer volunteer = new Volunteer();
                    volunteer.ParticipantId = (int)volInfo[0];
                    volunteer.ParticpiantFirstName = volInfo.GetString(1);
                    volunteer.ParticpiantLastName = volInfo.GetString(2);
                    volunteer.VolunteeringType = volInfo.GetString(3);

                    VolunteerInfoList.Add(volunteer);
                }

                return VolunteerInfoList;
            }
            catch(MySqlException ex)
            {
                return VolunteerInfoList;
            }

        }
    }
}
