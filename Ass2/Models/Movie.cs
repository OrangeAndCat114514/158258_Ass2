using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ass2.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Double Score { get; set; }
        public string URL { get; set; }
        public int? MovieCategoryID { get; set; }
        public virtual MovieCategory MovieCategory { get; set; }
    }
}