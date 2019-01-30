using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedSoftQuiz;



namespace RedSoftQuizTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestSimple()
        {
            Assert.AreEqual("128", Calculator.Calculate("8*12+4+7*4"));
        }

        [TestMethod]
        public void TestAddSpaces()
        {
            Assert.AreEqual((8 * 13 + 44 + 7 * 4).ToString(), Calculator.Calculate(" 8 *13 + 44 + 7 *4"));
        }
        [TestMethod]
        public void TestUseEqual()
        {
            Assert.AreEqual((8 * 12 + 4 + 7 * 4).ToString(), Calculator.Calculate("8*12+4+7*4="));
        }

        [TestMethod]
        public void TestAddBrackets()
        {
            Assert.AreEqual((8 * (13 + 44 + 7) * 4).ToString(), Calculator.Calculate(" 8 *(13 + 44 + 7) *4="));
        }

        [TestMethod]
        public void TestBigNums()
        {
            Assert.AreEqual(234500000245.ToString(), Calculator.Calculate("245+1000*2345*100000"));
        }

        [TestMethod]
        public void TestDiv()
        {
            Assert.AreEqual(93.2194570135746.ToString(), Calculator.Calculate("72+7/17-15/78+21="));
        }
        [TestMethod]
        public void TestLongExpression()
        {
            Assert.AreEqual((1+2+3+5+89+19*2+2*22+23/23*234+123*10/10*12).ToString(), 
                Calculator.Calculate("1+2+3+5+89+19*2+2*22+23/23*234+123*10/10*12"));
        }

        [TestMethod]
        public void TestLongExpressionWithBrackets()
        {
            Assert.AreEqual(((1 + 2) + 3 + 5 + (89 + 19) * (2 + 2) * 22 + 23 / 23 * (234 + 123) * 10 / 10 * 12).ToString(),
                Calculator.Calculate("(1+2)+3+5+(89+19)*(2+2)*22+23/23*(234+123)*10/10*12"));
        }
        [TestMethod]
        public void TestManyAddintions()
        {
            Assert.AreEqual((1 + 2 + 3 + 5 + 89 + 19 * 2 + 2 * 22 + 23 / 23 * 234 + 123 + 10 / 10 + 12).ToString(), 
                Calculator.Calculate("1+2+3+5+89+19*2+2*22+23/23*234+123+10/10+12"));
        }

        [TestMethod]
        public void TestDivByZero()
        {
            Assert.AreEqual("-бесконечность", Calculator.Calculate("1-7*2/0").ToString());
        }

        [TestMethod]
        public void TestDoubleValues()
        {
            Assert.AreEqual((72.243 + 7.524523 / 17.005 - 15.53454 / 78.16 + 21.13).ToString(), 
                Calculator.Calculate("72,243+7,524523/17,005-15,53454/78,16+21,13="));
        }


        [TestMethod]
        public void TestDoubleValuesBrackets()
        {
            Assert.AreEqual(((72.243 + 7.524523) / 17.005 - 15.53454 / (78.16 + 21.13)+3255 - 1234.1234).ToString(),
                Calculator.Calculate("(72,243+7,524523)/17,005-15,53454/(78,16+21,13)+3255 - 1234,1234="));
        }

    }
}
