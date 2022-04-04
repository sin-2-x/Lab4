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
    /*private string name;
    private string sum;
    private string description;*/

    public CurrentDebtor(Debtor CDebtor) {
            DataContext = CDebtor;//new CurretDebtorViewModel(CDebtor);
      InitializeComponent();

     

      

      /*name = CurrentDebtor.Name;
      sum = CurrentDebtor.Sum.ToString();
      description = "Описание";*/
    }
  }
}
