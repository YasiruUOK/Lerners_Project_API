using System;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ResultsController : ApiController
    {
        DataTable dt = new DataTable();
        static string ConnectionString = ConfigurationManager.ConnectionStrings["localNetwork"].ConnectionString;

        [Route("api/getResults/{indexNumber}")]
        [HttpGet]
        public Results getResults(int indexNumber)
        {
            Results results = new Results();

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString
                     , "getResults"
                     , new SqlParameter("@indexNumber", indexNumber)
                     );

            int count = ds.Tables[0].Rows.Count;
            // string result = JsonConvert.SerializeObject(ds);
            //return ds;
            if (count >= 0)
            {
                for (int i = 0; i < count; i++)
                {
                    results.IndexNumber = Int32.Parse(ds.Tables[0].Rows[i][0].ToString());
                    results.Result = ds.Tables[0].Rows[i][1].ToString();
                }
            }
            if (results.IndexNumber == 0)
            {
                results.Result = "Index Number Not Found";
            }
            return results;
        }
    }
}