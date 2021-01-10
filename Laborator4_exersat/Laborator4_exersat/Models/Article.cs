using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Laborator4_exersat.Models
{
    public class Article
    {
      
        [Key]
        public int Id { set; get; }
        [Required]
        public string Title { set; get; }
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { set; get; }

        public virtual Category Category { set; get; }
    }

    public class ArticleDBContext : DbContext
    {
        public ArticleDBContext() : base("DBConnectionString") { }
        public DbSet<Article> Articles { set; get; }
        public DbSet<Category> Categories { set; get; }
    }
}