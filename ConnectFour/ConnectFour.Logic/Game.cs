using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.Logic
{
    public class Game
    {
        private KeyValuePair<int, bool>[,] _fieldsMap = new KeyValuePair<int, bool>[7, 6];

        public KeyValuePair<int, bool>[,] FieldsMap { get => _fieldsMap; set => _fieldsMap = value; }

        public Game()
        {

        }

        private void resetFields()
        {
            //for(int i = 0; i < )
        }
    }
}
