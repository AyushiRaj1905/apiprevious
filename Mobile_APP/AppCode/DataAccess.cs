using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using static Mobile_APP.Models.FetchConfData;
using Mobile_APP.Models;
using MySql.Data.MySqlClient;


namespace Mobile_APP.AppCode
{
    public class DataAccess
    {

        public List<FetchConfData> FetchRoomData()

        {



            List<FetchConfData> lstFetchRoomData = new List<FetchConfData>();
            string myConnectionString = "Server= localhost; database=scheemabooking;uid=root;pWd=Ayushi@6299";


            try
            {
                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                string strcommmandtext = "SELECT * FROM scheemabooking.booking_table;";
                MySqlCommand comm = new MySqlCommand(strcommmandtext, conn);
             //   MySqlDataReader dataReader = comm.ExecuteReader();

                DataTable dat = new DataTable();

                dat.Load(comm.ExecuteReader());



                if (dat.Rows.Count > 0)



                {

                    for (int i = 0; i < dat.Rows.Count; i++)

                    {

                        FetchConfData objFetchRoomData = new FetchConfData();

                        objFetchRoomData.Booking_Date = Convert.ToString(dat.Rows[i]["Booking Date"]);

                        //objFetchRoomData.Booking_Day = Convert.ToString(dat.Rows[i]["Booking Day"]);

                        objFetchRoomData.Booking_to = Convert.ToString(dat.Rows[i]["Booking To"]);

                        objFetchRoomData.Booking_from = Convert.ToString(dat.Rows[i]["Booking From"]);

                        objFetchRoomData.Booking_Period = Convert.ToString(dat.Rows[i]["Booking Period"]);

                        objFetchRoomData.Booked_Purpose = Convert.ToString(dat.Rows[i]["Booking Purpose"]);

                        objFetchRoomData.Booked_Details = Convert.ToString(dat.Rows[i]["Booking Details"]);

                        objFetchRoomData.Participant_count = Convert.ToString(dat.Rows[i]["Participants Count"]);
                        objFetchRoomData.Booking_Id = Convert.ToString(dat.Rows[i]["Booking_ID"]);





                        lstFetchRoomData.Add(objFetchRoomData);

                    }



                }

                return lstFetchRoomData;



            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //   MessageBox.Show(ex.Message);
            }










            return lstFetchRoomData;

        }



    }
}