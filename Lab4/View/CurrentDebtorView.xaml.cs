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
      vm = new CurretDebtorViewModel(CDebtor);
      DataContext = vm.CurrentDebtor;
      InitializeComponent();
    }

    private void OkButtonClick(object sender, RoutedEventArgs e) {
      int.TryParse(sumTB.Text, out int newSum);

      string newPhotopath = photoImg.Source.ToString();
      newPhotopath = newPhotopath.Substring("file:///".Length);
      vm.SubmitChangesAsync(nameTB.Text, newSum, newPhotopath, descriptionTB.Text);
      Close();
    }

    private void imgMouseEnter(object sender, MouseEventArgs e) {
      ((Image)sender).Opacity = 0.7;
    }

    private void imgMouseLeave(object sender, MouseEventArgs e) {
      ((Image)sender).Opacity = 1;
    }

    private void imgMouseClick(object sender, MouseButtonEventArgs e) {

      OpenFileDialog op = new OpenFileDialog();
      op.Title = "Select a picture";
      op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
        "Portable Network Graphic (*.png)|*.png";
      if (op.ShowDialog() == true)
        photoImg.Source = new BitmapImage(new Uri(op.FileName));

    }
  }
}
