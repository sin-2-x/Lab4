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

namespace Lab4.VeiwModel
{
    public class DebtorsViewModel //: /*INotifyPropertyChanged,*/ //INotifyCollectionChanged
    {
        // Implements INotifyPropertyChanged interface to support bindings

        private ObservableCollection<Debtor> debtors;
        DebtorsModel db;
        //public event PropertyChangedEventHandler PropertyChanged;
        //public event NotifyCollectionChangedEventHandler CollectionChanged;
        public ObservableCollection<Debtor> Debtors
        {
            get
            {
                return debtors;
            }
            set
            {
                //helloString = value;
                //OnPropertyChanged();
            }
        }

/*        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventHandler(name));
        }*/

        public DebtorsViewModel()
        {
            db = new DebtorsModel();
            debtors =new ObservableCollection<Debtor>( db.GetData());
        }
    }
}
