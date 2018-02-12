using System;
using System.Collections.Generic;

namespace ConnectFour.Logic
{
    public class Game
    {
        public const int GAME_COLUMNS = 7;
        public const int GAME_ROWS_FOR_EACH_COLUMN = 6;
        public const int DEFAULT_STARTING_PLAYER = 1;

        // PLAYER 1 - RED
        // PLAYER 2 - YELLOW

        private KeyValuePair<int, bool>[,] _fieldsMap = new KeyValuePair<int, bool>[GAME_COLUMNS, GAME_ROWS_FOR_EACH_COLUMN];

        public KeyValuePair<int, bool>[,] FieldsMap { get => _fieldsMap; set => _fieldsMap = value; }

        private List<int> _fullColumns;
        public List<int> FullColumns { get => _fullColumns; set => _fullColumns = value; }

        public int CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }

        private int _currentPlayer;

        public Game()
        {
            CurrentPlayer = DEFAULT_STARTING_PLAYER;
        }

        public void AddPin(int column)
        {
            if (column < 0 || column > GAME_COLUMNS - 1)
                throw new ArgumentException("Bad column id provided");

            for(int i = 0; i < GAME_ROWS_FOR_EACH_COLUMN; i++)
            {
                //Checks if column is not full (will be guarded by the user gui, but an Exception needs to be thrown)
                if (FieldsMap[column, 0].Value == true)
                    throw new ArgumentException("You tried to add a pin to a full column!");

                //When there are no pins in current column
                if(FieldsMap[column, GAME_ROWS_FOR_EACH_COLUMN - 1].Value == false)
                {
                    FieldsMap[column, GAME_ROWS_FOR_EACH_COLUMN - 1] = new KeyValuePair<int, bool>(CurrentPlayer, true);
                    break;
                }

                if (FieldsMap[column, i].Value == false)
                {
                    continue;
                }
                else
                {
                    // var na = new KeyValuePair<int, bool>[GAME_COLUMNS, GAME_ROWS_FOR_EACH_COLUMN];
                    FieldsMap[column, i - 1] = new KeyValuePair<int, bool>(CurrentPlayer, true);
                    if (i == 1)
                        FullColumns.Add(column);
                    break;
                }
            }

            SwapPlayerTurn();
        }

        private void CheckWinningState()
        {
            int currentlyCheckedPinColor = 0;
            for(int col = 0; col < GAME_COLUMNS; col++)
            {
                for(int row = 0; row < GAME_ROWS_FOR_EACH_COLUMN; row++)
                {
                    if(FieldsMap[col,row].Value == true)
                    {
                        currentlyCheckedPinColor = FieldsMap[col, row].Key;
                        
                    }
                }
            }
        }

        private void SwapPlayerTurn()
        {
            switch(CurrentPlayer)
            {
                case 1:
                    CurrentPlayer = 2;
                    break;
                case 2:
                    CurrentPlayer = 1;
                    break;
            }
        }

        //Resets the board
        private void ResetFields()
        {
            FieldsMap = new KeyValuePair<int, bool>[GAME_COLUMNS, GAME_ROWS_FOR_EACH_COLUMN];
        }
    }
}
