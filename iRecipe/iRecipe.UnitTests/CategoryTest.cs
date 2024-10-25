using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using iRecipe.UnitTests;
using iRecipe.Data;
using iRecipe.Repositories.Interfaces;



namespace iRecipe.UnitTests
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void TestAdd()
        {

            //Category x = new Category();

            int num1 = 2, num2 = 2;
            var result = 4;

            Assert.AreEqual(num1 + num2, result);
        }
    }
}
