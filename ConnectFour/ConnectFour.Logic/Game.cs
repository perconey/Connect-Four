using System;
using System.Collections.Generic;

namespace ConnectFour.Logic
{
    public class Game
    {
        private const int GAME_COLUMNS = 7;
        private const int GAME_ROWS_FOR_EACH_COLUMN = 6;
        private const int DEFAULT_STARTING_PLAYER = 1;

        // PLAYER 1 - RED
        // PLAYER 2 - YELLOW

        private KeyValuePair<int, bool>[,] _fieldsMap = new KeyValuePair<int, bool>[GAME_COLUMNS, GAME_ROWS_FOR_EACH_COLUMN];

        public KeyValuePair<int, bool>[,] FieldsMap { get => _fieldsMap; set => _fieldsMap = value; }


        public int CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }
        private int _currentPlayer;

        public Game()
        {
            CurrentPlayer = DEFAULT_STARTING_PLAYER;
        }

        public void AddPin(int column)
        {
            for(int i = 0; i < GAME_ROWS_FOR_EACH_COLUMN; i++)
            {
                if (FieldsMap[column, i].Value == false)
                {
                    continue;
                }
                else
                {
                    // var na = new KeyValuePair<int, bool>[GAME_COLUMNS, GAME_ROWS_FOR_EACH_COLUMN];
                    FieldsMap[column, i - 1] = new KeyValuePair<int, bool>(CurrentPlayer, true);
                }
            }

            SwapPlayerTurn();
        }

        private void SwapPlayerTurn()
        {
            if (CurrentPlayer == 1)
                CurrentPlayer++;
            else
                CurrentPlayer--;
        }

        //Resets the board
        private void ResetFields()
        {
            FieldsMap = new KeyValuePair<int, bool>[GAME_COLUMNS, GAME_ROWS_FOR_EACH_COLUMN];
        }
    }
}
