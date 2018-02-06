using System.ComponentModel;

namespace ConnectFour.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {





        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
