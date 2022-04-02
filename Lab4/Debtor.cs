using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    //Класс для хранения в нем каждого отдельного субъекта базы данных
    public class Debtor : INotifyPropertyChanged
    {
        public Debtor()
        {
        }
        public Debtor(int id, string name, int sum)
        {
            this.Id = id;
            this.Name = name;
            this.Sum = sum;
        }




        [Key]
        private int id;
        private string name;
        private int sum;
        private string photo;


        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public int Sum { get { return sum; } set { sum = value; OnPropertyChanged("Sum"); } }
        public string Photo { get { return photo; } set { photo = Directory.GetCurrentDirectory() + value; OnPropertyChanged("Photo"); } }
        



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}




