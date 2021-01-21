using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EFCoreSQLiteXamFormsApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        
        private int _busyOperations = 0;


        public BaseViewModel() { }

        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        string _busyText;
        public string BusyText
        {
            get { return _busyText; }
            set { SetProperty(ref _busyText, value); }
        }

        object _bundle;
        public object Bundle
        {
            get { return _bundle; }
            set { SetProperty(ref _bundle, value); }
        }

        public virtual async Task InitAsync()
        {
            await Task.CompletedTask;
        }

        private readonly object _operationObj = new object();
        protected void StartOperation()
        {
            lock (_operationObj)
                _busyOperations++;

            IsBusy = _busyOperations != 0;
        }

        protected void FinishOperation()
        {
            lock (_operationObj)
                _busyOperations--;

            IsBusy = _busyOperations != 0;
        }

        public virtual async Task ExecuteAsync(Func<Task> action)
        {
            try
            {
                StartOperation();
                await action?.Invoke();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex?.Message);
            }
            finally
            {
                FinishOperation();
            }
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
