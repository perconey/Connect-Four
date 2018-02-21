﻿using ConnectFour.Logic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ConnectFour.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        private Game _game = new Game();
        private GameBoardMapper _mapper = new GameBoardMapper();
        private string[] mappedLocs = new string[42];
        private int notifiedWinner = 0;

        private string[] mappedDiscardedArrows = null;
        private string currentTurn;

        public ICommand Column1PinAddClick { get; set; }
        public ICommand Column2PinAddClick { get; set; }
        public ICommand Column3PinAddClick { get; set; }
        public ICommand Column4PinAddClick { get; set; }
        public ICommand Column5PinAddClick { get; set; }
        public ICommand Column6PinAddClick { get; set; }
        public ICommand Column7PinAddClick { get; set; }

        public ICommand ResetButtonClick { get; set; }

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

        public string[] MappedDiscardedArrows {
            get => mappedDiscardedArrows;
            set
            {
                mappedDiscardedArrows = value;
                NotifyPropertyChanged("MappedDiscardedArrows");
            }
        }

        public string CurrentTurn {
            get => currentTurn;
            set
            {
                currentTurn = value;
                NotifyPropertyChanged("CurrentTurn");
            }
        }

        public int NotifiedWinner
        {
            get => notifiedWinner;
            set
            {
                notifiedWinner = value;
               // MessageBox.Show("The winner is:" + NotifiedWinner);
                NotifyPropertyChanged("NotifiedWinner");
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
            ResetButtonClick = new RelayCommand(ResetClick, o => true);
            mappedLocs = Mapper.FileNameMapper;
            mappedDiscardedArrows = Mapper.ArrowIndicatorControllers;
            CurrentTurn = Mapper.CurrentTurn;
        }

        public void ResetClick(object o)
        {
            Game.Reset();
            Mapper.Reset();
            ResetViewModelMapping();
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
            //On player winning
            if (Mapper.WinnerChanged(Game))
            {
                Mapper.MapToFileNameWin(Game);
                NotifiedWinner = Game.WinnerId;
                Mapper.DiscardFilledColumnIndicators(Game);
                Mapper.UpdateTurnIndicator(Game);
            }
            //On normal turn
            else
            {
                Mapper.MapToFileName(Game);
                Mapper.DiscardFilledColumnIndicators(Game);
                Mapper.UpdateTurnIndicator(Game);
            }

            MappedLocs = Mapper.FileNameMapper;
            MappedDiscardedArrows = Mapper.ArrowIndicatorControllers;
            CurrentTurn = Mapper.CurrentTurn;
        }

        private void ResetViewModelMapping()
        {
            MappedLocs = Mapper.FileNameMapper;
            MappedDiscardedArrows = Mapper.ArrowIndicatorControllers;
            CurrentTurn = Mapper.CurrentTurn;
            Mapper.MapToFileName(Game);
            Mapper.DiscardFilledColumnIndicators(Game);
            Mapper.UpdateTurnIndicator(Game);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
