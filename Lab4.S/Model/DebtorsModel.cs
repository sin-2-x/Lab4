using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Model {
  public class DebtorsModel {
    ApplicationContext dbContext;


    public DebtorsModel(string connection = "DefaultConnection") {
      dbContext = new ApplicationContext(connection);
    }

    public DbSet<Debtor> GetData() {

      return dbContext.DebtorsDatabase;
    }


    // добавление
    public async Task AddAsync(Debtor newDebtor) {
      if (newDebtor != null) {
        
        dbContext.DebtorsDatabase.Add(newDebtor);
        await dbContext.SaveChangesAsync();
      }
    }

    // удаление
    public async Task DeleteAsync(Debtor deletingDebtor) {

      dbContext.DebtorsDatabase.Remove(deletingDebtor);
      await Task.Run(() => dbContext.SaveChanges());
    }

    public async Task EditAsync(Debtor editingDebtor) {
      // если ни одного объекта не выделено, выходим
      if (editingDebtor == null) return;


      Debtor a = dbContext.DebtorsDatabase.Find(editingDebtor.id);

      a.Name = editingDebtor.Name;
      a.Sum = editingDebtor.Sum;
      a.Photo = editingDebtor.Photo;
      a.Description = editingDebtor.Description;
      dbContext.Entry(a).State = EntityState.Modified;
      await Task.Run(() => dbContext.SaveChanges());

    }

  }
}
