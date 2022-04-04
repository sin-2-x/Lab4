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




    // добавление
    public void Add(Debtor newDebtor) {
      if (newDebtor != null) {
        Debtors.Add(newDebtor);
        SaveChanges();
      }
    }

    // удаление
    private void Delete(Debtor deletingDebtor) {
      // если ни одного объекта не выделено, выходим
      //if (phonesList.SelectedItem == null) return;
      // получаем выделенный объект
      //Phone phone = phonesList.SelectedItem as Phone;
      Debtors.Remove(deletingDebtor);
      SaveChanges();
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
