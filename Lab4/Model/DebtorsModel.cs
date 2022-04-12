using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Model {
  class DebtorsModel {
    ApplicationContext dbContext;


    public DebtorsModel() {
      dbContext = new ApplicationContext();
    }

    public List<Debtor> GetData() {

      return dbContext.DebtorsDatabase.ToList(); ;
    }


    // добавление
    public async Task AddAsync(Debtor newDebtor) {
      if (newDebtor != null) {

        dbContext.DebtorsDatabase.Add(newDebtor);
        await Task.Run(() => dbContext.SaveChanges());
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
