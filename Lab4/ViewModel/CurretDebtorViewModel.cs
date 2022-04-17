using GalaSoft.MvvmLight.CommandWpf;
using Lab4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab4.VeiwModel
{
    public class CurretDebtorViewModel //: INotifyPropertyChanged
    {
        ApplicationContext dbContext;

        private Debtor currentDebtorOriginal;
        private Debtor currentDebtorCopy;
        private CurrentDebtor window;

        public CurretDebtorViewModel(Debtor currentDebtor, CurrentDebtor window)
        {
            currentDebtorOriginal = currentDebtor;
            currentDebtorCopy = new Debtor(currentDebtor);
            this.window = window;
            dbContext = new ApplicationContext();
        }
        public Debtor CurrentDebtorCopy
        {
            get
            {
                return currentDebtorCopy;
            }
            set
            {
                currentDebtorCopy = value;
            }
        }

        private ICommand submitChangesCommand;
        public ICommand SubmitChangesCommand
        {
            get
            {

                return submitChangesCommand ?? (submitChangesCommand = new RelayCommand<Debtor>(
                    async obj =>
                    {
                        currentDebtorOriginal.Name = obj.Name;
                        currentDebtorOriginal.Sum = obj.Sum;
                        currentDebtorOriginal.Description = obj.Description;

                        if (obj.Photo.Contains("tmp"))
                        { //Если файл был изменен на временный
                            string newPhotoName = "Debtor" + currentDebtorOriginal.id.ToString() + "-" + Guid.NewGuid().ToString() + obj.PathToPhoto.Substring(obj.PathToPhoto.LastIndexOf('.')); //Генерируем новое имя
                            File.Copy(obj.PathToPhoto, Directory.GetCurrentDirectory() + "\\pics\\" + newPhotoName, true);//Копируем временный файл в новый с новым именем
                            string oldPhoto = currentDebtorOriginal.Photo; // Сохраняем название временного файла для его последующего удаления

                            currentDebtorOriginal.Photo = newPhotoName;
                            //File.Delete(Directory.GetCurrentDirectory() + "\\pics\\" + oldPhoto); //
                        }

                        if (dbContext.DebtorsDatabase.Find(currentDebtorOriginal.id) != null)
                        {
                            await new DebtorsModel().EditAsync(currentDebtorOriginal);
                        }
                        window.Close();
                    }
                    ));
            }
        }
    }
}

