using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Threading;
using Microsoft.Win32;

namespace DisableAbsoluteVolume.Logic
{
    class Service
    {
        private static RegistryKey DisVol = Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control\Bluetooth\Audio\AVRCP\CT", true);
        private static string Value = "DisableAbsoluteVolume";
        public static bool AbsoluteVolumeDisabled
        {
            get
            {
                var o = DisVol.GetValue(Value);
                return o.ToString() == "1" ? true : false;
            }
        }

        public static void ChangeValue()
        {
            var setting = AbsoluteVolumeDisabled ? 0 : 1;
            DisVol.SetValue(Value, setting, RegistryValueKind.DWord);
            var f = AbsoluteVolumeDisabled;
        }
    }
}