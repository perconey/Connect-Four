using System.Collections.Generic;
using System.Diagnostics;
using ConnectFour.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectFour.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DefTValCheck()
        {
            //Arrange
            var g = new Game();
            int i = 0;

            //Act
            var fm = g.FieldsMap;

            //Check
            ShowFields(fm);
        }

        [TestMethod]
        public void BoardColorCheck()
        {
            //Arrange
            var g = new Game();
            int i = 0;

            //Act
            var fm = g.FieldsMap;

            //Check
            ShowFieldsColors(fm);
        }


        [TestMethod]
        public void PinAddBlankTest()
        {
            //Arrange
            var g = new Game();
            int i = 0, l = 1;

            //Act
            var fm = g.FieldsMap;
            g.AddPin(2);

            //Check
            ShowFields(fm);
        }

        private void ShowFields(KeyValuePair<int, bool>[,] gameBoard)
        {
            Debug.Write("     ");
            for (int i = 0; i < 7; i++)
            {
                Debug.Write(i + 1 + "              ");
            }
           Debug.Write("\n");

            int row = 0, column = 0;
            for (row = 0; row < 6; row++)
            {
                for (column = 0; column < 7; column++)
                {
                    Debug.Write($"[{gameBoard[column,row].Key} , {gameBoard[column, row].Value}] ");
                }
                Debug.Write("\n");
            }
        }

        private void ShowFieldsColors(KeyValuePair<int, bool>[,] gameBoard)
        {
            Debug.Write("   ");
            for (int i = 0; i < 7; i++)
            {
                Debug.Write(i + 1 + "          ");
            }
            Debug.Write("\n");
            string color = "def";

            int row = 0, column = 0;
            for (row = 0; row < 6; row++)
            {
                for (column = 0; column < 7; column++)
                {
                    if (gameBoard[column, row].Key == 0)
                        color = "none";
                    if (gameBoard[column, row].Key == 1)
                        color = "yellow";
                    if (gameBoard[column, row].Key == 2)
                        color = "red";
                    Debug.Write($"[{color}] ");
                }
                Debug.Write("\n");
            }
        }
    }
}
