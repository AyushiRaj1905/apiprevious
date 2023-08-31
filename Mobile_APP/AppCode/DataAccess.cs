﻿using System;
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

        public List<FetchConfData> FetchRoomData2(Object input)

        {

            InputFetchRoom input_param = Newtonsoft.Json.JsonConvert.DeserializeObject<InputFetchRoom>(input.ToString());
            string Book_from_date = input_param.Booking_from_date;
            string Book_to_date = input_param.Booking_to_date;


            List<FetchConfData> lstFetchRoomData = new List<FetchConfData>();
            string myConnectionString = "Server= localhost; database=scheemabooking;uid=root;pWd=Ayushi@6299";


            try
            {
                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                string strcommmandtext = "SELECT * FROM scheemabooking.booking_table where booking_date between";
                strcommmandtext = strcommmandtext + "'" + Book_from_date + "'" + "and" + "'" + Book_to_date + "';";
                MySqlCommand comm = new MySqlCommand(strcommmandtext, conn);
                //   MySqlDataReader dataReader = comm.ExecuteReader();

                DataTable dat = new DataTable();

                dat.Load(comm.ExecuteReader());



                if (dat.Rows.Count > 0)



                {

                    for (int i = 0; i < dat.Rows.Count; i++)

                    {

                        FetchConfData objFetchRoomData = new FetchConfData();

                        objFetchRoomData.Booking_Date = Convert.ToString(dat.Rows[i]["booking_date"]);

                        //objFetchRoomData.Booking_Day = Convert.ToString(dat.Rows[i]["Booking Day"]);

                        objFetchRoomData.Booking_to = Convert.ToString(dat.Rows[i]["Booking_To"]);

                        objFetchRoomData.Booking_from = Convert.ToString(dat.Rows[i]["Booking_Form"]);

                        objFetchRoomData.Booking_Period = Convert.ToString(dat.Rows[i]["Booking_Period"]);

                        objFetchRoomData.Booked_Purpose = Convert.ToString(dat.Rows[i]["Booking_Purpose"]);

                        objFetchRoomData.Booked_Details = Convert.ToString(dat.Rows[i]["Booking_Details"]);

                        objFetchRoomData.Participant_count = Convert.ToString(dat.Rows[i]["Participants_Count"]);
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

                        objFetchRoomData.Booking_Date = Convert.ToString(dat.Rows[i]["booking_date"]);

                        //objFetchRoomData.Booking_Day = Convert.ToString(dat.Rows[i]["Booking Day"]);

                        objFetchRoomData.Booking_to = Convert.ToString(dat.Rows[i]["Booking_To"]);

                        objFetchRoomData.Booking_from = Convert.ToString(dat.Rows[i]["Booking_Form"]);

                        objFetchRoomData.Booking_Period = Convert.ToString(dat.Rows[i]["Booking_Period"]);

                        objFetchRoomData.Booked_Purpose = Convert.ToString(dat.Rows[i]["Booking_Purpose"]);

                        objFetchRoomData.Booked_Details = Convert.ToString(dat.Rows[i]["Booking_Details"]);

                        objFetchRoomData.Participant_count = Convert.ToString(dat.Rows[i]["Participants_Count"]);
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