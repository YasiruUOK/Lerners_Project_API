using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class NewsFeedController : ApiController
    {
        DataTable dt = new DataTable();
        static string ConnectionString = ConfigurationManager.ConnectionStrings["localNetwork"].ConnectionString;

        [Route("api/getAllNews")]
        [HttpGet]
        public List<NewsFeed> getAllNews()
        {
            List<NewsFeed> newsFeedList = new List<NewsFeed>();

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString
                     , "GetAllNews"
                     );

            int count = ds.Tables[0].Rows.Count;
            // string result = JsonConvert.SerializeObject(ds);
            //return ds;
            if (count >= 0)
            {
                for (int i = 0; i < count; i++)
                {
                    NewsFeed newsFeed = new NewsFeed();
                    newsFeed.ID = Int32.Parse(ds.Tables[0].Rows[i][0].ToString());
                    newsFeed.Topic = ds.Tables[0].Rows[i][1].ToString();
                    newsFeed.News = ds.Tables[0].Rows[i][2].ToString();
                    newsFeed.Added_Date = DateTime.Parse(ds.Tables[0].Rows[i][3].ToString());
                    newsFeed.Image_URL = ds.Tables[0].Rows[i][4].ToString();
                    newsFeedList.Add(newsFeed);
                }
            }
            return newsFeedList;
        }
    }
}