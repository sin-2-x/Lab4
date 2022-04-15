using GalaSoft.MvvmLight.CommandWpf;
using Lab4.Model;
using Lab4.View;
using Lab4.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
//using RelayCommand = GalaSoft.MvvmLight.CommandWpf.RelayCommand;
//using RelayCommand = Lab4.ViewModel.RelayCommand;

namespace Lab4.VeiwModel {
  public class DebtorsViewModel //: INotifyPropertyChanged//, INotifyCollectionChanged
  {


    private ObservableCollection<Debtor> debtors;
    DebtorsModel db;

    public DebtorsViewModel() {

      db = new DebtorsModel();
      debtors = new ObservableCollection<Debtor>(db.GetData());

      debtors.CollectionChanged += DebtorsCollectionChangedAsync;

    }
    public ObservableCollection<Debtor> Debtors {
      get {
        return debtors;
      }
      set {
        //helloString = value;
        //OnPropertyChanged();
      }
    }

    async void DebtorsCollectionChangedAsync(object sender, NotifyCollectionChangedEventArgs e) {

      /*if (e.Action == NotifyCollectionChangedAction.Add) {
        var a = (Debtor)((object[])e.NewItems.SyncRoot).ElementAt(0);

       // await db.AddAsync(a);
      }
      else if (e.Action == NotifyCollectionChangedAction.Remove) {
        await db.DeleteAsync((Debtor)((object[])e.OldItems.SyncRoot).ElementAt(0));
      }*/
    }


    private ICommand addCommand;
    public ICommand AddCommand {
      get {

        return addCommand ?? (addCommand = new RelayCommand(
            async () => {
              Debtor newDebtor = new Debtor() { Photo = "0.png" };
              new CurrentDebtor(newDebtor).ShowDialog();
              if (newDebtor.Name != "" && newDebtor.Sum > 0) {
                Debtors.Add(newDebtor);
                await db.AddAsync(newDebtor);
              }
            }
            ));
      }
    }

    private ICommand deleteCommand;
    public ICommand DeleteCommand {
      get {

        return deleteCommand ?? (deleteCommand = new RelayCommand<Debtor>(
            async obj => {
              var deleetingWindow = new SubmitDeletingWindow(obj);
              deleetingWindow.ShowDialog();
              if (deleetingWindow.vm.Change()) {
                Debtors.Remove(obj);
                await db.DeleteAsync(obj);
              }
            }
            ));
      }
    }

    private ICommand showCurrentDebtorWindowCommand;
    public ICommand ShowCurrentDebtorWindowCommand {
      get {

        return showCurrentDebtorWindowCommand ?? (showCurrentDebtorWindowCommand = new RelayCommand<Debtor>(
            obj => {
              new CurrentDebtor(obj).ShowDialog();
            }
            ));
      }
    }

  }

}
