using GalaSoft.MvvmLight.CommandWpf;
using Lab4.Model;
using Lab4.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace Lab4.VeiwModel {
  public class DebtorsViewModel : INotifyPropertyChanged {


    private ObservableCollection<Debtor> debtors;
    DebtorsModel db;
    public bool ShowGreetings {
      get {
        return bool.Parse(ConfigurationManager.AppSettings["showGreeting"]);
      }
      set {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        config.AppSettings.Settings["showGreeting"].Value = (value).ToString();
        config.Save();
        ConfigurationManager.RefreshSection("appSettings");
        OnPropertyChanged("ShowGreetings");
      }
    }

    public DebtorsViewModel() {

      db = new DebtorsModel();
      debtors = new ObservableCollection<Debtor>(db.GetData());
    }
    public ObservableCollection<Debtor> Debtors {
      get {
        return debtors;
      }
    }

    private ICommand addCommand;
    public ICommand AddCommand {
      get {

        return addCommand ?? (addCommand = new RelayCommand(
            async () => {
              Debtor newDebtor = new Debtor() { Photo = "0.png", Name=string.Empty,Description =string.Empty };
              new CurrentDebtor(newDebtor).ShowDialog();
              if (newDebtor.Name != "" && newDebtor.Sum >= 0) {
                debtors.Add(newDebtor);
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
                debtors.Remove(obj);
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

    double listBoxSize;
    public double ListBoxSize {
      get { return listBoxSize; }
      set { listBoxSize = value; OnPropertyChanged("ListBoxSize"); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "") {
      if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(prop));

      }
    }


    private ICommand saveToTxt;
    public ICommand SaveToTxt {
      get {

        return saveToTxt ?? (saveToTxt = new RelayCommand<ObservableCollection<Debtor>>(
            obj => {
              SaveFileDialog op = new SaveFileDialog();
              op.Title = "Выберите файл для записи";
              op.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
              if (op.ShowDialog() != DialogResult.Cancel) {
                var savelist = new StringBuilder();

                for (int i = 0; i < obj.Count; i++) {
                  savelist.Append(obj[i].id + " "
                          + obj[i].Name + " "
                          + obj[i].Photo + " "
                          + obj[i].Sum + " "
                          + obj[i].Description + "\n");
                }
                System.IO.File.WriteAllText(op.FileName, savelist.ToString());
              }
            }
            ));
      }
    }


    private ICommand changeBoolSetting;
    public ICommand ChangeBoolSetting {
      get {

        return changeBoolSetting ?? (changeBoolSetting = new RelayCommand<bool>(
            obj => {
              ShowGreetings = !obj;
            }
            ));
      }
    }

    private ICommand showAbout;
    public ICommand ShowAbout {
      get {

        return showAbout ?? (showAbout = new RelayCommand<bool>(
            obj => {
              new GreetingsView().ShowDialog();
            }
            ));
      }
    }
  }

}
