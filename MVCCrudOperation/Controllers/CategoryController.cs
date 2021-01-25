using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using MVCCrudOperation.Models;
using System.Configuration;

namespace MVCCrudOperation.Controllers
{
    public class CategoryController : Controller
    {

        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtcategory = new DataTable();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select * from category", con);
                ad.Fill(dtcategory);
            }
            return View(dtcategory);
        }


        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryModel catmodel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    string insertqry = "insert into Category values(@CategoryName)";
                    SqlCommand cmd = new SqlCommand(insertqry, con);
                    cmd.Parameters.AddWithValue("@CategoryName", catmodel.Category_Name);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            CategoryModel catemodel = new CategoryModel();
            DataTable dtfillCate = new DataTable();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string editqry = "select * from Category where Category_Id=@Category_Id";
                SqlDataAdapter ad = new SqlDataAdapter(editqry, con);
                ad.SelectCommand.Parameters.AddWithValue("@Category_Id", id);
                ad.Fill(dtfillCate);
            }
            if (dtfillCate.Rows.Count == 1)
            {
                catemodel.Category_Id = Convert.ToInt32(dtfillCate.Rows[0][0].ToString());
                catemodel.Category_Name = dtfillCate.Rows[0][1].ToString();
                return View(catemodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public ActionResult EditCategory(CategoryModel catmodel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    string Updateqry = "Update Category set Category_Name=@CategoryName where Category_Id=@CategoryId";
                    SqlCommand cmd = new SqlCommand(Updateqry, con);
                    cmd.Parameters.AddWithValue("@CategoryName", catmodel.Category_Name);
                    cmd.Parameters.AddWithValue("@CategoryId", catmodel.Category_Id);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteCategory(int id)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string deleteqry = "Delete from Category where Category_Id=@Categoryid";
                SqlCommand cmd = new SqlCommand(deleteqry, con);
                cmd.Parameters.AddWithValue("@Categoryid", id);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }


    }
}
