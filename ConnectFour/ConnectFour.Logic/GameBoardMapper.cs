
namespace ConnectFour.Logic
{
    public class GameBoardMapper
    {
        private string[] _fileNameMapper = new string[42];

        public string[] FileNameMapper { get => _fileNameMapper; set => _fileNameMapper = value; }

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
