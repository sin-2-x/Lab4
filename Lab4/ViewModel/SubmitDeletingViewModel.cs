using GalaSoft.MvvmLight.CommandWpf;
using Lab4.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab4.ViewModel {
  public class SubmitDeletingViewModel {
    public Debtor Debtor { get; set; }
    private SubmitDeletingWindow window;

    public SubmitDeletingViewModel(Debtor debtor, SubmitDeletingWindow window) {
      Debtor = debtor;
      this.window = window;
    }
    private bool clickYes = false;
    private bool clickNo = false;
    public bool Change() {
      if (clickNo) {
        return false;
      }
      else if (clickYes) {
        return true;
      }
      return false;
    }

    private ICommand buttonYes_Click;
    public ICommand ButtonYes_Click {
      get {

        return buttonYes_Click ?? (buttonYes_Click = new RelayCommand/*<Debtor>*/(
            () => {
              clickYes = true;
              Change();
              window.Close();
            }
            ));
      }
    }


    private ICommand buttonNo_Click;
    public ICommand ButtonNo_Click {
      get {

        return buttonNo_Click ?? (buttonNo_Click = new RelayCommand/*<Debtor>*/(
            () => {
              clickNo = true;
              Change();
              window.Close();
            }
            ));
      }
    }
  }
}
