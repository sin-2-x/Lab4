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

namespace Lab4 {
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    DebtorsViewModel vm;

    public MainWindow() {
      InitializeComponent();
      vm = new DebtorsViewModel();
      DataContext = vm;
      
    }

    private void ShowCurrentDebtorWindow(object sender, RoutedEventArgs e) {
      //Console.WriteLine(((DockPanel)((Button)sender).Parent).DataContext.ToString()) ;
      var current = (Debtor)((Grid)((Button)sender).Parent).DataContext;
      var grid = ((Grid)((Button)sender).Parent);
      new CurrentDebtor(current).ShowDialog();
      UpdateSourceImg(current);
      //vm.Debtors.ElementAt(((Debtor)((Grid)((Button)sender).Parent).DataContext).id)=
      //DataContext=new DebtorsViewModel();
      
    }

    private void AddBtnClick(object sender, RoutedEventArgs e) {
      Debtor newDebtor = new Debtor() { Photo = "0.png" };
      new CurrentDebtor(newDebtor).ShowDialog();
      if (newDebtor.Name != "" && newDebtor.Sum > 0) {
        vm.Debtors.Add(newDebtor);
      }
    }

    private void RemoveBtnClick(object sender, RoutedEventArgs e) {
      vm.Debtors.Remove((Debtor)((DockPanel)((Button)sender).Parent).DataContext);
    }
    private void UpdateSourceImg(Debtor current) {
     // current.
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

    }

    private void Image_SourceUpdated(object sender, DataTransferEventArgs e) {
      Console.WriteLine("ff");
    }
  }
}
