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
  public partial class CurrentDebtor : Window {

    Debtor ChangeDebtor;
    public CurrentDebtor(Debtor CDebtor) {

      ChangeDebtor = CDebtor;
      DataContext = CDebtor;//new CurretDebtorViewModel(CDebtor);
      InitializeComponent();

    }

    private void OkButtonClick(object sender, RoutedEventArgs e) {
      int newSum;
      int.TryParse(sumTB.Text, out newSum);
      ChangeDebtor.Sum = newSum;

      ChangeDebtor.Name = nameTB.Text;

      //Console.WriteLine(photoImg.Source.ToString());
      ChangeDebtor.Photo = photoImg.Source.ToString().Substring(photoImg.Source.ToString().LastIndexOf('/')-1);
      ChangeDebtor.Description = descriptionTB.Text;
      Close();

    }
  }
}
