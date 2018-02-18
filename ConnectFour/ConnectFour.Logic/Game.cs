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
        private int _currentPlayer;
        private List<int> _fullColumns = new List<int>();
        private int _turnsCount;
        private List<KeyValuePair<int, int>> fieldsToCheck = new List<int>();

        public KeyValuePair<int, bool>[,] FieldsMap { get => _fieldsMap; set => _fieldsMap = value; }

        public List<int> FullColumns { get => _fullColumns; set => _fullColumns = value; }

        public int CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }

        public int TurnsCount { get => _turnsCount; set => _turnsCount = value; }

        public List<KeyValuePair<int,int>> FieldsToCheck { get => fieldsToCheck; set => fieldsToCheck = value; }

        public int Winner = 0;

        public Game()
        {
            TurnsCount = 0;
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
                    FieldsToCheck.Add(new KeyValuePair<int, int>(column, GAME_ROWS_FOR_EACH_COLUMN - 1));
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
                    FieldsToCheck.Add(new KeyValuePair<int, int>(column, i - 1));
                    if (i == 1)
                        FullColumns.Add(column);
                    break;
                }
            }

            SwapPlayerAndNextTurn();

            if(TurnsCount >= 7)
            CheckWinningState();
        }

        private void CheckWinningState()
        {
            foreach(var item in FieldsToCheck)
            {
                int currentlyCheckedPinColor = 0;
                currentlyCheckedPinColor = FieldsMap[item.Key, item.Value].Key;
                // ->
                try
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if ((FieldsMap[item.Key + i, item.Value].Value == true && FieldsMap[item.Key + i, item.Value].Key == currentlyCheckedPinColor))
                        {
                            if (i == 3)
                            {
                                Winner = currentlyCheckedPinColor;
                                return;
                            }
                            continue;
                        }
                        else
                            break;
                    }
                }
                catch (Exception ex) { }

                try
                {
                    for(int i = 1; i < 4; i++)
                    {
                        // \|/
                        if ((FieldsMap[item.Key, item.Value + i].Value == true && FieldsMap[item.Key, item.Value + i].Key == currentlyCheckedPinColor))
                        {
                            if (i == 3)
                            {
                                Winner = currentlyCheckedPinColor;
                                return;
                            }
                            continue;
                        }
                        else
                            break;
                    }
                }
                catch (Exception ex) { }

                // \|\
                try
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if ((FieldsMap[item.Key + i, item.Value + i].Value == true && FieldsMap[item.Key + i, item.Value + i].Key == currentlyCheckedPinColor))
                        {
                            if (i == 3)
                            {
                                Winner = currentlyCheckedPinColor;
                                return;
                            }
                            continue;
                        }
                        else
                            break;
                    }
                }
                catch (Exception ex) { }

                // / bottom left
                try
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if ((FieldsMap[item.Key - i, item.Value + i].Value == true && FieldsMap[item.Key - i, item.Value + i].Key == currentlyCheckedPinColor))
                        {
                            if (i == 3)
                            {
                                Winner = currentlyCheckedPinColor;
                                return;
                            }
                            continue;
                        }
                        else
                            break;
                    }
                }
                catch (Exception ex) { }
            }
        }

        private void SwapPlayerAndNextTurn()
        {
            TurnsCount++;
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

        //Resets the game
        private void Reset()
        {
            TurnsCount = 0;
            FieldsMap = new KeyValuePair<int, bool>[GAME_COLUMNS, GAME_ROWS_FOR_EACH_COLUMN];
        }
    }
}
