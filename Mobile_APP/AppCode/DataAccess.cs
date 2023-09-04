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

        public string AddBooking(Object input)

        {

            AddBookingInput input_param = Newtonsoft.Json.JsonConvert.DeserializeObject<AddBookingInput>(input.ToString());
            string Booking_from = input_param.Booking_from;
            string Booking_to = input_param.Booking_to;
            string conference_room = input_param.conference_room;
            string Booking_Date = input_param.Booking_Date;
            string Booking_Day = input_param.Booking_Day;
            string Booking_Period = input_param.Booking_Period;
            string Booked_Details = input_param.Booked_Details;
            string Booked_Purpose = input_param.Booked_Purpose;
            string Booking_Id = input_param.Booking_Id;
            string Participant_count = input_param.Participant_count;
            string Emp_Dept = input_param.Emp_Dept;
            string Emp_name = input_param.Emp_name;
            string Emp_Desg = input_param.Emp_Desg;
            string Emp_No = input_param.Emp_No;
           // string Employee_Id=input_param.Employee_Id



            string str = "";
            string myConnectionString = "Server= localhost; database=scheemabooking;uid=root;pWd=Ayushi@6299";


            try
            {
                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
               // conn.Open();
                string strcommmandtext1 = "Insert into scheemabooking.employee_table values "+ "(";
                strcommmandtext1 = strcommmandtext1 + "'" + Emp_No + "'"+","  + "'" + Emp_name + "',";
                strcommmandtext1 = strcommmandtext1 + "'" + Emp_Desg + "'" + "," + "'" + Emp_Dept + "');";
                string strcommmandtext2 = "Insert into scheemabooking.booking_table values " + "(";
                strcommmandtext2 = strcommmandtext2 + "'" + Booking_Id + "'" + "," + "'" + Booking_Date + "',";
                strcommmandtext2 = strcommmandtext2 + "'" + Booking_from + "'" + "," + "'" + Booking_to + "',";
                strcommmandtext2 = strcommmandtext2 + "'" + Booking_Period + "'" + "," + "'" + Booked_Details + "',";
                strcommmandtext2 = strcommmandtext2 + "'" + Booked_Purpose + "'" + "," + "'" + Participant_count + "',";
                strcommmandtext2 = strcommmandtext2 + "'" + conference_room +"',"+"'"+ Emp_No+ "');";

               // MySqlCommand comm = new MySqlCommand(strcommmandtext1, conn);
                //   MySqlDataReader dataReader = comm.ExecuteReader();
               // comm.ExecuteReader();
               // conn.Close();
                conn.Open();
                MySqlCommand comm2 = new MySqlCommand(strcommmandtext2, conn);
                comm2.ExecuteReader();
                conn.Close();
                str = "Data has been inserted";
                //DataTable dat = new DataTable();

                // dat.Load(comm.ExecuteReader());



                return str;



                }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //   MessageBox.Show(ex.Message);
                str = ex.Message.ToString();
            }

            return str;



            }
        

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

                        objFetchRoomData.Conference_Room = Convert.ToString(dat.Rows[i]["Confrence_RoomNo"]);

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
                        objFetchRoomData.Conference_Room = Convert.ToString(dat.Rows[i]["Confrence_RoomNo"]);

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