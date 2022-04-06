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
            InitializeComponent();
            vm = new DebtorsViewModel();
            DataContext = vm;
        }

        private void ShowCurrentDebtorWindow(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(((DockPanel)((Button)sender).Parent).DataContext.ToString()) ;
            new CurrentDebtor((Debtor)((DockPanel)((Button)sender).Parent).DataContext).Show();
        }

        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            var newDebtor = new Debtor();
            new CurrentDebtor(newDebtor).ShowDialog();
            //listBoxDebtors.Items.Add(newDebtor);
            vm.Debtors.Add(newDebtor);
            //
        }
    }
}
