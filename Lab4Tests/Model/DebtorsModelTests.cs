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
    static DebtorsModel db = new DebtorsModel("TestConnection");

    [TestMethod()]
    public async Task Test_2_DeleteAsync() {
      var list = db.GetData().ToList();
      for (int i = 0; i < list.Count-1; i++) {
        await db.DeleteAsync(list.ElementAt(i));
      }
      Assert.AreEqual(db.GetData().ToList().Count, 1);
    }

    [TestMethod()]
    public async Task Test_1_AddAsyncTestAsync() {

      int countBefore = db.GetData().ToList().Count;
      Debtor a = new Debtor(0, "n", 1, "ph", "d");
      await db.AddAsync(a);
      await db.AddAsync(a);
      int countAfter = db.GetData().ToList().Count;
      Assert.AreEqual(countBefore, countAfter-2);
    }
    [TestMethod()]
    public async Task Test_3_EditAsyncTestAsync() {
      Debtor deb = db.GetData().First();
      deb.Name = "N";
      await db.EditAsync(deb);

      Assert.AreEqual(db.GetData().First().Name, "N");
    }
  }
}