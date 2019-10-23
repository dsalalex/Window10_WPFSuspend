using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVM_TestSuspend3.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            TriggerErrorCommand = new DelegateCommand(triggerError);

            MyString = "Hello World";
        }

        private string myString;

        public string MyString
        {
            get { return myString; }
            set { SetProperty(ref myString, value); }
        }

        public DelegateCommand TriggerErrorCommand { get; set; }

        private void triggerError()
        {
            MyString = "Error";
            throw new Exception("Error");
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName]string name = null)
        {
            bool propertyChanged = false;

            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(name);
                propertyChanged = true;
            }

            return propertyChanged;
        }

        protected void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

    }
}
