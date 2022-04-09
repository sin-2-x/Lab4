using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;


namespace Lab4.Model {

  public class ApplicationContext : DbContext {
    public ApplicationContext() : base("DefaultConnection") {
    }
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

      optionsBuilder.UseSQLite(@"DataSource=mydatabase.db;");
    }*/
    public DbSet<Debtor> Debtors { get; set; }


  }

}
