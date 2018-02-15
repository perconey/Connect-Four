using ConnectFour.Logic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ConnectFour.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        private Game _game = new Game();
        private GameBoardMapper _mapper = new GameBoardMapper();
        private string[] mappedLocs = null;

        public ICommand Column1PinAddClick { get; set; }
        public ICommand Column2PinAddClick { get; set; }
        public ICommand Column3PinAddClick { get; set; }
        public ICommand Column4PinAddClick { get; set; }
        public ICommand Column5PinAddClick { get; set; }
        public ICommand Column6PinAddClick { get; set; }
        public ICommand Column7PinAddClick { get; set; }

        public Game Game { get => _game; set => _game = value; }
        public GameBoardMapper Mapper
        {
            get => _mapper;
            set
            {
                _mapper = value;
            }
        }

        public string[] MappedLocs {
            get => mappedLocs;
            set
            {
                mappedLocs = value;
                NotifyPropertyChanged("MappedLocs");
            }
        }

        public MainWindowViewModel()
        {
            Column1PinAddClick = new RelayCommand(Column1Click, o => true);
            Column2PinAddClick = new RelayCommand(Column2Click, o => true);
            Column3PinAddClick = new RelayCommand(Column3Click, o => true);
            Column4PinAddClick = new RelayCommand(Column4Click, o => true);
            Column5PinAddClick = new RelayCommand(Column5Click, o => true);
            Column6PinAddClick = new RelayCommand(Column6Click, o => true);
            Column7PinAddClick = new RelayCommand(Column7Click, o => true);
            mappedLocs = Mapper.FileNameMapper;
        }

        public void Column1Click(object o)
        {
            Game.AddPin(0);
            UpdateMapping();
        }

        public void Column2Click(object o)
        {
            Game.AddPin(1);
            UpdateMapping();
        }
        public void Column3Click(object o)
        {
            Game.AddPin(2);
            UpdateMapping();
        }
        public void Column4Click(object o)
        {
            Game.AddPin(3);
            UpdateMapping();
        }
        public void Column5Click(object o)
        {
            Game.AddPin(4);
            UpdateMapping();
        }
        public void Column6Click(object o)
        {
            Game.AddPin(5);
            UpdateMapping();
        }
        public void Column7Click(object o)
        {
            Game.AddPin(6);
            UpdateMapping();
        }

        private void UpdateMapping()
        {
            Mapper.MapToFileName(Game);
            MappedLocs = Mapper.FileNameMapper;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
