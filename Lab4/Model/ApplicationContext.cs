using System.Data.Entity;


namespace Lab4.Model {

  public class ApplicationContext : DbContext {
    public ApplicationContext() : base("DefaultConnection") {
    }
    public DbSet<Debtor> DebtorsDatabase { get; set; }

  }

}
