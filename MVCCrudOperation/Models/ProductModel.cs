using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MVCCrudOperation.Models
{
    public class ProductModel
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
        public DataTable dtcateg { get; set; }


    }
}