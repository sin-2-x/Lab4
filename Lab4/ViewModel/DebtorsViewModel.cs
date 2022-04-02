using Lab4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.VeiwModel
{
    class DebtorsViewModel : INotifyPropertyChanged
    {
        // Implements INotifyPropertyChanged interface to support bindings

        private List<Debtor> debtors; 

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Debtor> HelloString
        {
            get
            {
                return debtors;
            }
            set
            {
                //helloString = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DebtorsViewModel()
        {
            var DebtorsModel = new DebtorsModel();
            debtors = DebtorsModel.GetData();
        }

    }
}
