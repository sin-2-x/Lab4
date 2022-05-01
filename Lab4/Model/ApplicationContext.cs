using System;
using System.Data.Entity;
using System.IO;

namespace Lab4.Model {

  public class ApplicationContext : DbContext {
    public ApplicationContext(string connection = "DefaultConnection") : base(connection) {

      //var a = Directory.GetCurrentDirectory();
    }
    public DbSet<Debtor> DebtorsDatabase { get; set; }

  }

}
