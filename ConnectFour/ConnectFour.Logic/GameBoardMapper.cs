
namespace ConnectFour.Logic
{
    public class GameBoardMapper
    {
        private string[] _fileNameMapper = new string[42];
        private string[] _arrowIndicatorControllers = new string[7]
        {
            "Visible","Visible","Visible","Visible","Visible","Visible","Visible"
        };


        public string[] FileNameMapper { get => _fileNameMapper; set => _fileNameMapper = value; }
        public string[] ArrowIndicatorControllers { get => _arrowIndicatorControllers; set => _arrowIndicatorControllers = value; }

        public GameBoardMapper()
        {

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
                            FileNameMapper[index] = "";
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
