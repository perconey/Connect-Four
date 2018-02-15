
namespace ConnectFour.Logic
{
    public class GameBoardMapper
    {
        private string[] _fileNameMapper = new string[42];
        private string[] _arrowIndicatorControllers = new string[7]
        {
            "Visible","Visible","Visible","Visible","Visible","Visible","Visible"
        };
        private string currentTurn = "";

        public string[] FileNameMapper { get => _fileNameMapper; set => _fileNameMapper = value; }
        public string[] ArrowIndicatorControllers { get => _arrowIndicatorControllers; set => _arrowIndicatorControllers = value; }
        public string CurrentTurn { get => currentTurn; set => currentTurn = value; }

        public GameBoardMapper()
        {
            GetDefaultStartingPlayerMap();
        }    

        public void GetDefaultStartingPlayerMap()
        {
            switch(Game.DEFAULT_STARTING_PLAYER)
            {
                case 1:
                    currentTurn = "/Resources/pyellow.png";
                    break;
                case 2:
                    currentTurn = "/Resources/pred.png";
                    break;
                default:
                    break;
            }
            //Unreachable code marked due to compiler not knowing the possibility to change DSP with config file
        }

        public void UpdateTurnIndicator(Game gm)
        {
            switch (gm.CurrentPlayer)
            {
                case 1:
                    currentTurn = "/Resources/pyellow.png";
                    break;
                case 2:
                    currentTurn = "/Resources/pred.png";
                    break;
                default:
                    break;
            }

        }

        public void DiscardFilledColumnIndicators(Game gm)
        {
            foreach(var item in gm.FullColumns)
            {
                ArrowIndicatorControllers[item] = "Hidden";
            }
        }

        public void MapToFileName(Game gm)
        {
            int column, row;
            int index = 0;
            for(column = 0; column < 7; column++)
            {
                for(row = 0; row < 6; row++)
                {
                   int imp = gm.FieldsMap[column, row].Key;
                    switch(imp)
                    {
                        case 0:
                            FileNameMapper[index] = " ";
                            break;
                        case 1:
                            FileNameMapper[index] = "/Resources/pyellow.png";
                            break;
                        case 2:
                            FileNameMapper[index] = "/Resources/pred.png";
                            break;
                    }
                    index++;
                }
            }
        }
    }
}
