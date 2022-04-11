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
    public DbSet<Debtor> DebtorsDatabase { get; set; }

  }

}
