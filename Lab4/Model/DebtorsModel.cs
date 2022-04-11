using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Model
{
    class DebtorsModel
    {
        ApplicationContext dbContext;
        private List<Debtor> repositoryData;

        public DebtorsModel()
        {
            dbContext = new ApplicationContext();
        }

        public List<Debtor> GetData()
        {

            repositoryData = dbContext.DebtorsDatabase.ToList();
            return repositoryData;
        }


        // добавление
        public void Add(Debtor newDebtor)
        {
            if (newDebtor != null)
            {

                dbContext.DebtorsDatabase.Add(newDebtor);
                Console.WriteLine(dbContext.SaveChanges());
            }
        }

        // удаление
        public void Delete(Debtor deletingDebtor)
        {

            dbContext.DebtorsDatabase.Remove(deletingDebtor);
            dbContext.SaveChanges();
        }

        public void Edit(Debtor editingDebtor)
        {
            // если ни одного объекта не выделено, выходим
            if (editingDebtor == null) return;


            Debtor a = dbContext.DebtorsDatabase.Find(editingDebtor.id);

            a.Name = editingDebtor.Name;
            a.Sum = editingDebtor.Sum;
            a.Photo = editingDebtor.Photo;
            a.Description = editingDebtor.Description;
            dbContext.Entry(a).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

    }
}
