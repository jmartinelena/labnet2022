using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExceptions.Tests
{
    [TestClass()]
    public class RandomExtensionsTests
    {
        [TestMethod()]
        public void CoinFlipTest()
        {
            int randomSeed = 1;
            Random random = new Random(randomSeed);
            bool expected = false;

            bool actual = random.CoinFlip(); // con esta seed, esto deberia siempre retornar false.
            
            Assert.IsFalse(actual);
        }
    }
}