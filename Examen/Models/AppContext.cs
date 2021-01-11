using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class AppContext:DbContext
    {
        public AppContext() : base("DBExamen") {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext,Examen.Migrations.Configuration>("DBExamen"));
        }
        //Adaugarea modelelor in context
        //In controllere vom adauga private Models.AppContext db=new Models.AppContext()
        public DbSet<Meeting> Meetings;
        public DbSet<Subject> Subjects;
    }
}