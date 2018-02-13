using ConnectFour.Logic;
using System.ComponentModel;
using System.Windows.Input;

namespace ConnectFour.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand Column1PinAddClick { get; set; }
        public ICommand Column2PinAddClick { get; set; }
        public ICommand Column3PinAddClick { get; set; }
        public ICommand Column4PinAddClick { get; set; }
        public ICommand Column5PinAddClick { get; set; }
        public ICommand Column6PinAddClick { get; set; }
        public ICommand Column7PinAddClick { get; set; }

        private Game _game = new Game();
        public Game Game { get => _game; set => _game = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
