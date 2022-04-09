using System;
using System.Collections.Generic;
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
    private void Delete(Debtor deletingDebtor) {
      // если ни одного объекта не выделено, выходим
      //if (phonesList.SelectedItem == null) return;
      // получаем выделенный объект
      //Phone phone = phonesList.SelectedItem as Phone;
      repositoryData.Remove(deletingDebtor);
      db.SaveChanges();
    }

/*    private void Edit_Click() {
      // если ни одного объекта не выделено, выходим
      if (phonesList.SelectedItem == null) return;
      // получаем выделенный объект
      Phone phone = phonesList.SelectedItem as Phone;

      PhoneWindow phoneWindow = new PhoneWindow(new Phone {
        Id = phone.Id,
        Company = phone.Company,
        Price = phone.Price,
        Title = phone.Title
      });

      if (phoneWindow.ShowDialog() == true) {
        // получаем измененный объект
        phone = db.Phones.Find(phoneWindow.Phone.Id);
        if (phone != null) {
          phone.Company = phoneWindow.Phone.Company;
          phone.Title = phoneWindow.Phone.Title;
          phone.Price = phoneWindow.Phone.Price;
          db.Entry(phone).State = EntityState.Modified;
          db.SaveChanges();
        }
      }
    }*/

  }
}
