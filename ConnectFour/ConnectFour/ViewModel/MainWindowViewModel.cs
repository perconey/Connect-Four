using ConnectFour.Logic;
using System.ComponentModel;
using System.Windows;
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

        public GameBoardMapper mapper = new GameBoardMapper();


        public MainWindowViewModel()
        {
            Column1PinAddClick = new RelayCommand(Column1Click, o => true);
            Column2PinAddClick = new RelayCommand(Column2Click, o => true);
            Column3PinAddClick = new RelayCommand(Column3Click, o => true);
            Column4PinAddClick = new RelayCommand(Column4Click, o => true);
            Column5PinAddClick = new RelayCommand(Column5Click, o => true);
            Column6PinAddClick = new RelayCommand(Column6Click, o => true);
            Column7PinAddClick = new RelayCommand(Column7Click, o => true);

        }

        public void Column1Click(object o)
        {
            MessageBox.Show("Popup 1");
        }

        public void Column2Click(object o)
        {
            MessageBox.Show("Popup 2");
        }
        public void Column3Click(object o)
        {
            MessageBox.Show("Popup 3");
        }
        public void Column4Click(object o)
        {
            MessageBox.Show("Popup 4");
        }
        public void Column5Click(object o)
        {
            MessageBox.Show("Popup 5");
        }
        public void Column6Click(object o)
        {
            MessageBox.Show("Popup 6");
        }
        public void Column7Click(object o)
        {
            MessageBox.Show("Popup 7");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
