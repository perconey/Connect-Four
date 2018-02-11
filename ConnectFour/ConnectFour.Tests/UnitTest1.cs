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
            int i = 0, l = 1;

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
            int i = 0, l = 1;

            //Act
            var fm = g.FieldsMap;
            Debug.Write("     ");
            for (i = 0; i < 7; i++)
            {
                Debug.Write(i + 1 + "              ");
            }

            //Check
            foreach (var item in fm)
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

        [TestMethod]
        public void PinAddBlankTest()
        {
            //Arrange
            var g = new Game();
            int i = 0, l = 1;

            //Act
            var fm = g.FieldsMap;
            g.AddPin(2);

            Debug.Write("     ");
            for (i = 0; i < 7; i++)
            {
                Debug.Write(i + 1 + "              ");
            }

            //Check
            ShowFields(fm);
        }

        private void ShowFields(KeyValuePair<int, bool>[,] gameBoard)
        {
            int i = 0 , l = 1;
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
