
namespace ConnectFour.Logic
{
    public class GameBoardMapper
    {
        private string[,] _fileNameMapper = new string[7, 6];

        public string[,] FileNameMapper { get => _fileNameMapper; set => _fileNameMapper = value; }

        public void MapToFileName(Game gm)
        {
            int column, row;
            for(column = 0; column < 7; column++)
            {
                for(row = 0; row < 6; row++)
                {
                   var imp = gm.FieldsMap[column, row].Key;
                    switch(imp)
                    {
                        case 0:
                            FileNameMapper[column, row] = "";
                            break;
                        case 1:
                            FileNameMapper[column, row] = "/Resources/pyellow.png";
                            break;
                        case 2:
                            FileNameMapper[column, row] = "/Resources/pred.png";
                            break;
                    }
                }
            }
        }
    }
}
