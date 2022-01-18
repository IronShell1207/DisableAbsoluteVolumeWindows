using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DisableAbsoluteVolume.Logic;
using DisableAbsoluteVolume.ViewModels;
using DisableAbsoluteVolume.ViewModels.Base;

namespace DisableAbsoluteVolume.ViewModels
{
    public class MainView : ViewModel
    {
        public string DisableAbsoluteValue { get; set; } 

        public string ButtonValue { get; set; }
        public bool SuccessNadpisVisib { get; set; } = false;
        #region ChangeValueCommand

        public ICommand ChangeValueCommand { get; }

        private bool CanChangeValueCommandExecute(object p)
        {
            return true;
        }

        private async void OnChangeValueCommandExecuting(object p)
        {
            Service.ChangeValue();
            var procExplorer = Process.GetProcessesByName("explorer");
            foreach (Process proc in procExplorer)
            {
                proc.Kill();
            }

            Process.Start("explorer.exe");
            var disstatus = Service.AbsoluteVolumeDisabled;
            DisableAbsoluteValue = disstatus ? "Disabled ✅" : "Enabled ❌";
            ButtonValue = disstatus ? "Return defaults" : "Fix volume";
            SuccessNadpisVisib = true;
            OnPropertyChanged("SuccessNadpisVisib");
            OnPropertyChanged("DisableAbsoluteValue");
            OnPropertyChanged("ButtonValue");
        }

// 

        #endregion

       public MainView()
        {
            ChangeValueCommand = new LambdaCommand(OnChangeValueCommandExecuting, CanChangeValueCommandExecute);
            var disstatus = Service.AbsoluteVolumeDisabled;
            DisableAbsoluteValue = disstatus ? "Disabled ✅" : "Enabled ❌";
            ButtonValue = disstatus ? "Return defaults" : "Fix volume";

        }

    }
}
