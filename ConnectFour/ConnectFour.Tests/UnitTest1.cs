using System;
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
            foreach(var item in fm)
            {
                if (i % 7 == 0)
                    Debug.Write("\n");

                Debug.WriteLine($"{item.Key} , {item.Value}");
                i++;
            }
        }
    }
}
