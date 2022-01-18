using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace DisableAbsoluteVolume.ViewModels.Base
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Передача свойства и события для генерации события
        /// </summary>
        /// <param name="PropertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        /// <summary>
        /// Обновление значение свойства, для которого определено поле, в котором это свойство хранит свои данные. Также данный метод разрешает кольцевые изменения свойств. Когда система изменяет одно свойство, она может сразу обновлять и последующие
        /// </summary>
        /// <typeparam name="T">Ссылка на поле свойства</typeparam>
        /// <param name="field">Новое значение для установки в поле</param>
        /// <param name="value"></param>
        /// <param name="PropertyName">Автоматический параметр для компилятора (имя обновляемого свойства)</param>
        /// <returns></returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
        public void Disposed()
        {
            Dispose(true);
        }

        private bool _Disposed;
        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposing || _Disposed) return;
            _Disposed = true;
        }
    }
}