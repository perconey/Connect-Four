using System;
using System.Collections.Generic;

namespace ConnectFour.Logic
{
    public class Game
    {
        private KeyValuePair<int, bool>[,] _fieldsMap = new KeyValuePair<int, bool>[7, 6];

        public KeyValuePair<int, bool>[,] FieldsMap { get => _fieldsMap; set => _fieldsMap = value; }

        public Game()
        {

        }

        //Resets the board
        private void ResetFields()
        {
            FieldsMap = new KeyValuePair<int, bool>[7,6];
        }
    }
}
