using GalaSoft.MvvmLight.CommandWpf;
using Lab4.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab4.ViewModel
{
    class GreetingsWindowViewModel : INotifyPropertyChanged
    {


        /*public bool ShowGreetings
        {
            get
            {
                return !bool.Parse(ConfigurationManager.AppSettings["showGreeting"]);
            }
            set
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["showGreeting"].Value = (!value).ToString();
                config.Save();
            }
        }*/

       // private ICommand adCommand;

        public event PropertyChangedEventHandler PropertyChanged;

       /* public ICommand AdCommand
        {
            get
            {

                return adCommand ?? (adCommand = new RelayCommand<bool>(
                     (check) =>
                     {
                         ShowGreetings = check;
                     }));
            }
        }*/

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));

            }
        }

        string text;
        double width = 0;
        public string Text { get { return text; } set { text = value; OnPropertyChanged("Text"); } }
        public double Width { get { return width; } set { width = value; OnPropertyChanged("Width"); } }
        public GreetingsWindowViewModel(string message)
        {
            //his.StartPosition = FormStartPosition.Manual;


            Text = message;
            //Width = win.label.ActualWidth+20;
            /*Point magin = textMessage.Location;

            Size = new Size(magin.X * 2 + textMessage.Width, magin.Y * 3 + textMessage.Height);
            //FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(left - Width / 2, top - Height / 2);*/

        }


    }
}
