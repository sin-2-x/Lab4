using GalaSoft.MvvmLight.CommandWpf;
using Lab4.Model;
using Lab4.View;
using Lab4.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Lab4.VeiwModel
{
    public class DebtorsViewModel : INotifyPropertyChanged//, INotifyCollectionChanged
    {


        private ObservableCollection<Debtor> debtors;
        DebtorsModel db;
        public bool ShowGreetings
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["showGreeting"]);
            }
            set
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["showGreeting"].Value = (value).ToString();
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
                OnPropertyChanged("ShowGreetings");
            }
        }

        public DebtorsViewModel()
        {

            db = new DebtorsModel();
            debtors = new ObservableCollection<Debtor>(db.GetData());

            //debtors.CollectionChanged += DebtorsCollectionChangedAsync;
            Console.WriteLine(ConfigurationManager.AppSettings["showGreeting"]);
            //ShowGreetings = bool.Parse(ConfigurationManager.AppSettings["showGreeting"]);

            
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

        /*    async void DebtorsCollectionChangedAsync(object sender, NotifyCollectionChangedEventArgs e) {

              if (e.Action == NotifyCollectionChangedAction.Add) {
                var a = (Debtor)((object[])e.NewItems.SyncRoot).ElementAt(0);

               // await db.AddAsync(a);
              }
              else if (e.Action == NotifyCollectionChangedAction.Remove) {
                await db.DeleteAsync((Debtor)((object[])e.OldItems.SyncRoot).ElementAt(0));
              }
            }*/


        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {

                return addCommand ?? (addCommand = new RelayCommand(
                    async () =>
                    {
                        Debtor newDebtor = new Debtor() { Photo = "0.png" };
                        new CurrentDebtor(newDebtor).ShowDialog();
                        if (newDebtor.Name != "" && newDebtor.Sum > 0)
                        {
                            Debtors.Add(newDebtor);
                            await db.AddAsync(newDebtor);
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

                return deleteCommand ?? (deleteCommand = new RelayCommand<Debtor>(
                    async obj =>
                    {
                        var deleetingWindow = new SubmitDeletingWindow(obj);
                        deleetingWindow.ShowDialog();
                        if (deleetingWindow.vm.Change())
                        {
                            Debtors.Remove(obj);
                            await db.DeleteAsync(obj);
                        }
                    }
                    ));
            }
        }

        private ICommand showCurrentDebtorWindowCommand;
        public ICommand ShowCurrentDebtorWindowCommand
        {
            get
            {

                return showCurrentDebtorWindowCommand ?? (showCurrentDebtorWindowCommand = new RelayCommand<Debtor>(
                    obj =>
                    {
                        new CurrentDebtor(obj).ShowDialog();
                    }
                    ));
            }
        }

        double listBoxSize;
        public double ListBoxSize { get { return listBoxSize; } 
            set { listBoxSize = value; OnPropertyChanged("ListBoxSize"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));

            }
        }


        private ICommand saveToTxt;
        public ICommand SaveToTxt
        {
            get
            {

                return saveToTxt ?? (saveToTxt = new RelayCommand<ObservableCollection<Debtor>>(
                    obj =>
                    {
                    SaveFileDialog op = new SaveFileDialog();
                    op.Title = "Выберите файл для записи";
                    op.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                        if (op.ShowDialog() != DialogResult.Cancel)
                        {
                            var savelist = new StringBuilder();

                            for (int i = 0; i < obj.Count; i++)
                            {
                                savelist.Append( obj[i].id + " " 
                                + obj[i].Name + " " 
                                + obj[i].Photo+ " " 
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
        public ICommand ChangeBoolSetting
        {
            get
            {

                return changeBoolSetting ?? (changeBoolSetting = new RelayCommand<bool>(
                    obj =>
                    {
                        ShowGreetings = !obj;
                    }
                    ));
            }
        }

        //new GreetingsWindowViewModel("Кр № 455555555555555555555555555555555555555555555555555555555555", this);
        private ICommand showAbout;
        public ICommand ShowAbout
        {
            get
            {

                return showAbout ?? (showAbout = new RelayCommand<bool>(
                    obj =>
                    {
                        new View.GreetingsView().ShowDialog();

                    }
                    ));
            }
        }
    }

}
