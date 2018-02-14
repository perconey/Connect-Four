using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.Logic
{
    public class GameBoardMapper
    {
        private string[,] _fileNameMapper = new string[7, 6];

        public string[,] FileNameMapper { get => _fileNameMapper; set => _fileNameMapper = value; }
    }
}
