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
            Debug.Write("     ");
            for(i = 0; i < 7; i++)
            {
                Debug.Write(i + 1 + "              ");
            }

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
            Debug.Write("     ");
            for (i = 0; i < 7; i++)
            {
                Debug.Write(i + 1 + "              ");
            }

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
            int i = 0, l = 1;
            foreach (var item in gameBoard)
            {
                if (i % 7 == 0)
                {
                    Debug.Write("\n" + l);
                    l++;
                }
                if (item.Key == 0)
                    Debug.Write($"[none]     ");
                if (item.Key == 1)
                    Debug.Write($"[yellow]   ");
                if (item.Key == 2)
                    Debug.Write($"[red]      ");
                i++;
            }
        }
    }
}
