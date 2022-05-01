using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite.EF6;
using System.Threading.Tasks;

namespace Lab4.Model {
  [TestClass()]
  public class DebtorsModelTests {


    static Debtor a = new Debtor(0, "n", 1, "ph", "d");
    [TestMethod()]
    public void AddAsyncTestAsync() {
      DebtorsModel db = new DebtorsModel("TestConnection");

      var v = db.GetData().ToList();
      db.AddAsync(a);
      Assert.AreEqual(v, 1);
    }
    //[TestMethod()]
    /*    public async Task EditAsyncTestAsync() {
          a.Name = "N";
          await db.EditAsync(a);

          Assert.AreEqual(db.GetData().ElementAt(0).Name, "N");
        }*/
  }
}