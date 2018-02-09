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
            foreach(var item in fm)
            {
                if (i % 7 == 0)
                {
                    Debug.Write("\n" + l);
                    l++;
                }

                Debug.Write($"[{item.Key} , {item.Value}] ");
                i++;
            }
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
                    Debug.Write($"[none] ");
                if (item.Key == 1)
                    Debug.Write($"[yellow] ");
                if (item.Key == 2)
                    Debug.Write($"[red] ");
                i++;
            }
        }
    }
}
