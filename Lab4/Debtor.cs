using Microsoft.SqlServer.Management.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        /*    public Debtor() {
            }*/
        /*public Debtor(int id, string name, int sum, string photo, string description) {
          //this.Id = id;
          this.id = id;
          this.Name = name;
          this.Sum = sum;
          this.Photo = photo;
          this.Description = description;
        }*/
        public Debtor() { }
        public Debtor(Debtor objToCopy)
        {
            this.id = objToCopy.id;
            this.Name = objToCopy.name;
            this.Sum = objToCopy.sum;
            this.Photo = objToCopy.photo;
            this.Description = objToCopy.description;
        }


        //private int id;
        private string name;
        private int sum;
        private string photo;
        private string description;

        [NotMapped]
        public string PathToPhoto
        {
            get
            {
                return Directory.GetCurrentDirectory() + "\\pics\\" + photo;
            }
            set
            {
                Photo = value.Substring(value.LastIndexOf('\\') + 1);
                OnPropertyChanged("PathToPhoto");
            }
        }

        [Key]
        public int id { get; set; }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public int Sum { get { return sum; } set { sum = value; OnPropertyChanged("Sum"); } }
        public string Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                OnPropertyChanged("Photo");
                OnPropertyChanged("PathToPhoto");
            }
        }
        public string Description { get { return description; } set { description = value; OnPropertyChanged("Description"); } }



        public event PropertyChangedEventHandler PropertyChanged;
        //public event DataTransferEventHandler DataTransfer;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));

            }
        }
        /*        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                }*/
    }
}




