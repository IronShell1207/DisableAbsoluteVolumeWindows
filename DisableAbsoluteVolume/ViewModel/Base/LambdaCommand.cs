using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using DisableAbsoluteVolume.ViewModels.Base;

namespace DisableAbsoluteVolume.ViewModels
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> Execute, Func<object, bool> canExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = canExecute;
        }

        public override bool CanExecute(object p) => _CanExecute?.Invoke(p) ?? true;

        public override void Execute(object p) => _Execute(p);
    }
}
