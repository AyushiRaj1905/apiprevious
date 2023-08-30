using Mobile_APP.AppCode;
using Mobile_APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Security.Cryptography.X509Certificates;
using MySql.Data.MySqlClient;






namespace Mobile_APP.Controllers
{


    public class QueryBookingController : ApiController
    {
        // GET: QueryBooking
        //public ActionResult Index()
        //{
        //    return View();
        //}


        


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/FetchRoomData")]
        public  List<FetchConfData> FetchBooking()
        {     
                     

                List<FetchConfData> lstFectchRoomData = new List<FetchConfData>();
                try
                {

                    
                DataAccess _da = new DataAccess();
                    lstFectchRoomData = _da.FetchRoomData();

                }

                catch (Exception ex)

                {



                }

                return lstFectchRoomData;





            }

        





    }
}