using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Model {
  class DebtorsModel {
    ApplicationContext db;
    private List<Debtor> repositoryData;

    public DebtorsModel() {
      db = new ApplicationContext();
    }

    public List<Debtor> GetData() {

      repositoryData = db.Debtors.ToList();
      return repositoryData;
    }
    // добавление
    public void Add(Debtor newDebtor) {
      if (newDebtor != null) {

        db.Debtors.Add(newDebtor);
        Console.WriteLine(db.SaveChanges());
      }
    }

    // удаление
    public void Delete(Debtor deletingDebtor) {
      // если ни одного объекта не выделено, выходим
      //if (phonesList.SelectedItem == null) return;
      // получаем выделенный объект
      //Phone phone = phonesList.SelectedItem as Phone;
      db.Debtors.Remove(deletingDebtor);
      //repositoryData.Remove(deletingDebtor);
      Console.WriteLine(db.SaveChanges());
    }

    public void Edit(Debtor editingDebtor) {
      // если ни одного объекта не выделено, выходим
      if (editingDebtor == null) return;

      //if (phoneWindow.ShowDialog() == true) {
      // получаем измененный объект

      Debtor a = db.Debtors.Find(editingDebtor.id);
      //if (phone != null) {
      a.Name = editingDebtor.Name;
      a.Sum = editingDebtor.Sum;
      a.Photo = editingDebtor.Photo;
      a.Description = editingDebtor.Description;
      db.Entry(a).State = EntityState.Modified;
      db.SaveChanges();
      //}
      //}
    }

  }
}
