using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCCrudOperation.Models
{
    public class CategoryModel
    {
        public int Category_Id { get; set; }

        [Required(ErrorMessage ="Category Name is Required")]
        public string Category_Name { get; set; }


    }
}