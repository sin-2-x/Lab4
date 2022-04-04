using Lab4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.VeiwModel {
  public class DebtorsViewModel : INotifyPropertyChanged {
    // Implements INotifyPropertyChanged interface to support bindings

    private List<Debtor> debtors;
    DebtorsModel db;
    public event PropertyChangedEventHandler PropertyChanged;

    public List<Debtor> Debtors {
      get {
        return debtors;
      }
      set {
        //helloString = value;
        OnPropertyChanged();
      }
    }

    protected void OnPropertyChanged([CallerMemberName] string name = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public DebtorsViewModel() {
      db = new DebtorsModel();
      debtors = db.GetData();
    }
  }
}
