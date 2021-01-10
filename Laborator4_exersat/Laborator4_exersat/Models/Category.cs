using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laborator4_exersat.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { set; get; }
        [Required]
        public string CategoryName { set; get; }
        public virtual ICollection <Article> Articles {set;get;}
    }
}