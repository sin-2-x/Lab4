using Lab4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.VeiwModel {
  public class CurretDebtorViewModel : INotifyPropertyChanged {
    // Implements INotifyPropertyChanged interface to support bindings

    private Debtor currentDebtor;

    public event PropertyChangedEventHandler PropertyChanged;

    public Debtor CurrentDebtor {
      get {
        return currentDebtor;
      }
      set {
        currentDebtor = value;
        OnPropertyChanged();
      }
    }

    protected void OnPropertyChanged([CallerMemberName] string name = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public CurretDebtorViewModel(Debtor currentDebtor) {
      this.CurrentDebtor = currentDebtor;
    }
  }
}
