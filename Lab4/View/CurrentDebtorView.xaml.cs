using Lab4.VeiwModel;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Lab4 {

  public partial class CurrentDebtor : Window {
    CurretDebtorViewModel vm;
    public CurrentDebtor(Debtor CDebtor) {

      vm = new CurretDebtorViewModel(CDebtor, this);
      DataContext = vm;
      InitializeComponent();
    }
    private void imgMouseEnter(object sender, MouseEventArgs e) {
      ((Image)sender).Opacity = 0.7;
    }

    private void imgMouseLeave(object sender, MouseEventArgs e) {
      ((Image)sender).Opacity = 1;
    }

    private void imgMouseClick(object sender, MouseButtonEventArgs e) {

      OpenFileDialog op = new OpenFileDialog {
        Title = "Select a picture",
        Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
        "Portable Network Graphic (*.png)|*.png"
      };
      if (op.ShowDialog() == true) {
        string newPhotoName = "tmp" + op.FileName.Substring(op.FileName.LastIndexOf('.'));
        string newPhotoPath = Directory.GetCurrentDirectory() + "\\pics\\" + newPhotoName;
        File.Copy(op.FileName, newPhotoPath, true);
        vm.CurrentDebtorCopy.PathToPhoto = newPhotoPath;
      }
    }

    private void sumTB_TextChanged(object sender, TextChangedEventArgs e) {
      string a = ((TextBox)sender).Text;

      for (int i = 0; i < a.Length; i++) {
        if (!(a[i] >= '0' && a[i] <= '9')) {
          a = a.Remove(i, 1);
        }
      }
      ((TextBox)sender).Text = a;
    }
  }
}
