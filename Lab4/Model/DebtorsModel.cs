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
  }
}
