using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class CurrentDebtor : Window
    {

        Debtor ChangeDebtor;
        public CurrentDebtor()
        {
            DataContext = ChangeDebtor;
            InitializeComponent();

        }
        public CurrentDebtor(Debtor CDebtor)
        {

            ChangeDebtor = CDebtor;
            DataContext = CDebtor;
            InitializeComponent();

        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            int.TryParse(sumTB.Text, out int newSum);
            ChangeDebtor.Sum = newSum;

            ChangeDebtor.Name = nameTB.Text;

            if (photoImg.Source == null)
                ChangeDebtor.Photo = "0.png";
            else
            {
                string newPhotopath = photoImg.Source.ToString();
                newPhotopath = newPhotopath.Substring("file:///".Length);
                string newPhotoFolder = newPhotopath.Remove(newPhotopath.LastIndexOf('/') + 1);
                string newPhotoName = newPhotopath.Substring(newPhotopath.LastIndexOf('/') + 1);
                string oldPhotoName = ChangeDebtor.Photo.Substring(ChangeDebtor.Photo.LastIndexOf('\\') + 1);
                File.Copy(newPhotopath, Directory.GetCurrentDirectory() + "\\pics\\" + newPhotoName, true);
                ChangeDebtor.Photo = newPhotoName;
            }
            ChangeDebtor.Description = descriptionTB.Text;
            Close();

        }

        private void imgMouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 0.7;
        }

        private void imgMouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 1;
        }

        private void imgMouseClick(object sender, MouseButtonEventArgs e)
        {

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
