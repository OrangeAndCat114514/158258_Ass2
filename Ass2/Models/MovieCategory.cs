using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ass2.Models
{
    public class MovieCategory
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    
}
}