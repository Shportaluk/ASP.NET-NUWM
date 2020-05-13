using ASP.NET_NUWM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_NUWM.Controllers
{
    public class HomeController : Controller
    {
        static SqlConnection _con = new SqlConnection("workstation id=nuwmaspnet.mssql.somee.com;packet size=4096;user id=nuwm_aspnet_SQLLogin_1;pwd=k6h9mbq5y8;data source=nuwmaspnet.mssql.somee.com;persist security info=False;initial catalog=nuwmaspnet");


        public ActionResult Index()
        {
            List<PageInfo> listPages = GetListPages();
            ViewBag.listPages = listPages;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AddPage()
        {
            return View();
        }
        public ActionResult Page(string id)
        {

            ViewBag.pageInfo = GetPageById(id);
            return View();
        }


        public PageInfo GetPageById( string id )
        {
            PageInfo page = new PageInfo();
            string comm = "SELECT * FROM nuwmaspnet_pages WHERE Id = @id";

            SqlCommand sqlComm = new SqlCommand(comm, _con);

            SqlParameter Param1 = new SqlParameter("@id", System.Data.SqlDbType.Int);

            Param1.Value = int.Parse(id);

            sqlComm.Parameters.Add(Param1);

            _con.Open();
            SqlDataReader reader = sqlComm.ExecuteReader();
            while (reader.Read())
            {
                page = new PageInfo(
                    reader[0].ToString().TrimStart().TrimEnd(),
                    reader[1].ToString().TrimStart().TrimEnd(),
                    reader[2].ToString().TrimStart().TrimEnd(),
                    reader[3].ToString().TrimStart().TrimEnd(),
                    reader[4].ToString().TrimStart().TrimEnd()
                    );
            }

            _con.Close();
            

            return page;
        }

        public List<PageInfo> GetListPages()
        {
            List<PageInfo> listPages = new List<PageInfo>();
                string comm = "SELECT * FROM nuwmaspnet_pages";

                SqlCommand sqlComm = new SqlCommand(comm, _con);

                _con.Open();
                SqlDataReader reader = sqlComm.ExecuteReader();
                while (reader.Read())
                {
                    PageInfo page = new PageInfo(
                        reader[0].ToString().TrimStart().TrimEnd(),
                        reader[1].ToString().TrimStart().TrimEnd(),
                        reader[2].ToString().TrimStart().TrimEnd(),
                        reader[3].ToString().TrimStart().TrimEnd(),
                        reader[4].ToString().TrimStart().TrimEnd()
                        );
                    listPages.Add(page);
                }

                _con.Close();

            return listPages;
        }
        public string AddPageToDB(string category, string title, string description, string urlImg)
        {
            if (category != null && title != null && urlImg != null)
            {
                string comm = "INSERT INTO nuwmaspnet_pages VALUES( @category, @title, @description,@urlImg)";

                SqlCommand sqlComm = new SqlCommand(comm, _con);

                SqlParameter Param1 = new SqlParameter("@category", System.Data.SqlDbType.NVarChar);
                SqlParameter Param2 = new SqlParameter("@title", System.Data.SqlDbType.NVarChar);
                SqlParameter Param3 = new SqlParameter("@description", System.Data.SqlDbType.NVarChar);
                SqlParameter Param4 = new SqlParameter("@urlImg", System.Data.SqlDbType.NVarChar);

                Param1.Value = category;
                Param2.Value = title;
                Param3.Value = description;
                Param4.Value = urlImg;

                sqlComm.Parameters.Add(Param1);
                sqlComm.Parameters.Add(Param2);
                sqlComm.Parameters.Add(Param3);
                sqlComm.Parameters.Add(Param4);

                _con.Open();
                SqlDataReader reader = sqlComm.ExecuteReader();

                _con.Close();
            }

            return "";
        }

    }
}