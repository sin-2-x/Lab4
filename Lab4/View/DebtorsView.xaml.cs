using Lab4.VeiwModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DebtorsViewModel vm;

        public MainWindow()
        {
            vm = new DebtorsViewModel();
            InitializeComponent();
            DataContext = vm;
            /*if (vm.ShowGreetings) {
                
            }*/

            this.Loaded += (o, e) =>
            {
                if (vm.ShowGreetings)
                    showGreetings();
            };
        }

        void showGreetings() {
            var s = new View.GreetingsView() { Owner = this };
                s.ShowDialog();
        }
        private void listBoxDebtors_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            vm.ListBoxSize = ((ListBox)sender).ActualWidth - 35;
        }
    }
}
