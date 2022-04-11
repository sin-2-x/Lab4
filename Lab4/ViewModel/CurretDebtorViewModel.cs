using Lab4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.VeiwModel
{
    public class CurretDebtorViewModel //: INotifyPropertyChanged
    {
        ApplicationContext dbContext;



        private Debtor currentDebtor;

        //public event PropertyChangedEventHandler PropertyChanged;
        public CurretDebtorViewModel(Debtor currentDebtor)
        {
            this.CurrentDebtor = currentDebtor;

            dbContext = new ApplicationContext();
        }
        public Debtor CurrentDebtor
        {
            get
            {
                return currentDebtor;
            }
            set
            {
                currentDebtor = value;
//               OnPropertyChanged();
            }
        }


/*        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }*/

        public void SubmitChanges(string name, int sum, string photopath, string description)
        {
            CurrentDebtor.Name = name;
            CurrentDebtor.Sum = sum;
            CurrentDebtor.Description = description;




            //Вот тут



            //string newPhotoName = "Debtor" + CurrentDebtor.id.ToString() + photopath.Substring(photopath.LastIndexOf('.'));
            
            //File.Copy(photopath, Directory.GetCurrentDirectory() + "\\pics\\" + newPhotoName, true);
            //CurrentDebtor.Photo = newPhotoName;


            if(dbContext.DebtorsDatabase.Find(currentDebtor.id) != null)
                new DebtorsModel().Edit(currentDebtor);
        }
    }
}
