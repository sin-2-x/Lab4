using Lab4.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.VeiwModel {
  public class DebtorsViewModel //: INotifyPropertyChanged//, INotifyCollectionChanged
  {
    

    private ObservableCollection<Debtor> debtors;
    DebtorsModel db;
    //public event PropertyChangedEventHandler PropertyChanged;
   // public event NotifyCollectionChangedEventHandler CollectionChanged;

    
    public ObservableCollection<Debtor> Debtors {
      get {
        return debtors;
      }
      set {
        //helloString = value;
        //OnPropertyChanged();
      }
    }

   /* protected void OnPropertyChanged([CallerMemberName] string name = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }*/

    void DebtorsCollectionChanged(object sender,NotifyCollectionChangedEventArgs e) {
      
      if (e.Action == NotifyCollectionChangedAction.Add) {
        Console.WriteLine("добавление");
        var a = (Debtor)((object[])e.NewItems.SyncRoot).ElementAt(0);
        
        db.Add(a);
      }
      else if (e.Action == NotifyCollectionChangedAction.Remove) {
        Console.WriteLine("удаление");
        db.Delete((Debtor)((object[])e.OldItems.SyncRoot).ElementAt(0));
      }

      
    }

    public DebtorsViewModel() {

      db = new DebtorsModel();
      debtors = new ObservableCollection<Debtor>(db.GetData());
      /*foreach (var debtor  in debtors) {
        debtor.PropertyChanged += OnPropertyChanged;
      }*/
      debtors.CollectionChanged += DebtorsCollectionChanged;
      
    }

/*    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
     // Console.WriteLine("Изменен");
    }*/
  }
}
