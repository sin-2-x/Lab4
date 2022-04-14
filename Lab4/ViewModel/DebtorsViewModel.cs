using GalaSoft.MvvmLight.CommandWpf;
using Lab4.Model;
using Lab4.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using RelayCommand = Lab4.ViewModel.RelayCommand;

namespace Lab4.VeiwModel
{
    public class DebtorsViewModel //: INotifyPropertyChanged//, INotifyCollectionChanged
    {


        private ObservableCollection<Debtor> debtors;
        DebtorsModel db;

        public DebtorsViewModel()
        {

            db = new DebtorsModel();
            debtors = new ObservableCollection<Debtor>(db.GetData());

            debtors.CollectionChanged += DebtorsCollectionChangedAsync;

        }
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

        async void DebtorsCollectionChangedAsync(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var a = (Debtor)((object[])e.NewItems.SyncRoot).ElementAt(0);

                await db.AddAsync(a);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                await db.DeleteAsync((Debtor)((object[])e.OldItems.SyncRoot).ElementAt(0));
            }
        }


        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                
                return addCommand ?? (addCommand = new RelayCommand(
                    obj =>
                    {
                        Debtor newDebtor = new Debtor() { Photo = "0.png" };
                        new CurrentDebtor(newDebtor).ShowDialog();
                        if (newDebtor.Name != "" && newDebtor.Sum > 0)
                        {
                            Debtors.Add(newDebtor);
                        }
                    }
                    ));
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {

                return deleteCommand ?? (deleteCommand = new RelayCommand/*<Debtor>*/(
                    obj =>
                    {
                        Debtors.Remove((Debtor)obj);
                    }
                    ));
            }
        }


    }

}
