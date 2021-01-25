using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MVCCrudOperation.Models;
using System.Configuration;

namespace MVCCrudOperation.Controllers
{
    public class ProductController : Controller
    {
        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        [HttpGet]
        public ActionResult Index(int pagerow=1,int Record=1)
        {
            DataTable dtproduct = new DataTable();
            DataTable dtcount = new DataTable();
            int count;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select * from Product p left join category c on p.category_Id=c.category_Id order by p.Product_Id offset (@pagerow-1) * 10 rows fetch next 10 rows only", con);
                    ad.SelectCommand.Parameters.AddWithValue("@pagerow", pagerow);
                    ad.Fill(dtproduct);
                    SqlDataAdapter ad1 = new SqlDataAdapter("select count(*) as Count from Product", con);
                    ad1.Fill(dtcount);
                    count = int.Parse(dtcount.Rows[0]["Count"].ToString());
                    ViewBag.page = Math.Ceiling(count / 10.0);

                ViewBag.pagerow = pagerow;
            }
            return View(dtproduct);
        }


        [HttpGet]
        public ActionResult AddProduct()
        {
            ProductModel ProductModel = new ProductModel();
            DataTable dtcategory = new DataTable();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                ProductModel.dtcateg = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter("select * from category", con);
                ad.Fill(ProductModel.dtcateg);
            }
            return View(ProductModel);
        }

        
        [HttpPost]
        public ActionResult AddProduct(ProductModel ProdtModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    string insertqry = "insert into Product values(@CategoryId,@ProductName)";
                    SqlCommand cmd = new SqlCommand(insertqry, con);
                    cmd.Parameters.AddWithValue("@CategoryId", ProdtModel.Category_Id);
                    cmd.Parameters.AddWithValue("@ProductName", ProdtModel.Product_Name);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }

            }
            catch(Exception ex)
            {
                return View();
            }
        }
        
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            ProductModel productModel = new ProductModel();
            DataTable dtfillproduct = new DataTable();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string editqry = "select * from Product p left join category c on p.category_Id=c.category_Id where Product_Id=@Product_Id";
                SqlDataAdapter ad = new SqlDataAdapter(editqry, con);
                ad.SelectCommand.Parameters.AddWithValue("@Product_Id", id);
                ad.Fill(dtfillproduct);
                productModel.dtcateg = new DataTable();
                SqlDataAdapter ad1 = new SqlDataAdapter("select * from category", con);
                ad1.Fill(productModel.dtcateg);
            }
            if (dtfillproduct.Rows.Count == 1)
            {
                productModel.Product_Id = Convert.ToInt32(dtfillproduct.Rows[0][0].ToString());
                productModel.Category_Id = Convert.ToInt32(dtfillproduct.Rows[0][1].ToString());
                productModel.Product_Name = dtfillproduct.Rows[0][2].ToString();
                productModel.Category_Name = dtfillproduct.Rows[0][4].ToString();

                
                return View(productModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public ActionResult EditProduct(ProductModel productModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    string insertqry = "Update Product set Product_Name=@ProductName,Category_Id=@CategoryId where Product_Id=@Product_Id";
                    SqlCommand cmd = new SqlCommand(insertqry, con);
                    cmd.Parameters.AddWithValue("@CategoryId",productModel.Category_Id);
                    cmd.Parameters.AddWithValue("@ProductName",productModel.Product_Name);
                    cmd.Parameters.AddWithValue("@Product_Id", productModel.Product_Id);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }


        public ActionResult DeleteProduct(int id)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string deleteqry = "Delete from Product where Product_Id=@Productid";
                SqlCommand cmd = new SqlCommand(deleteqry, con);
                cmd.Parameters.AddWithValue("@Productid", id);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

       
    }
}
