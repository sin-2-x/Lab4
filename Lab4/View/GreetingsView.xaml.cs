using Lab4.ViewModel;
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
using System.Windows.Shapes;

namespace Lab4.View
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class GreetingsView : Window
    {
        GreetingsWindowViewModel vm;
        public GreetingsView()
        {
            vm = new GreetingsWindowViewModel("Работа №4. \nМногопроцессорное и многопоточное программирование. \nНеобходимо написать программу хранящую список должников.");
            DataContext = vm;
            InitializeComponent();
            
            //this.Loaded += (o, s) => { MakeVM(); };
        }

      /*  void MakeVM() {
            
        }
*/
    }
}
