using Acumatica;
using NUnit.Framework;

namespace AcumaticaTest
{
    public class IncrementorTests
    {
        IStrIncrementor incrementor;
           [SetUp]
        public void Setup()
        {
            incrementor = new StrIncrementor();
        }

        [TestCase("000002", "000003",  TestName = "TC-10010", Description = "Main scenario test , simple increment , overflow is not occurs")]
        [TestCase("999999", "000000", TestName = "TC-10011", Description = "Main scenario test ,  increment , overflow  occurs")]
        [TestCase("GL-321", "GL-322", TestName = "TC-10013", Description = "Main scenario test ,  increment ,string with prefix overflow is not occurs ")]
        [TestCase("GL-999", "GL-000", TestName = "TC-10014", Description = "Main scenario test ,  increment ,string with prefix overflow occurs ")]
        
        [TestCase("DRI000EDERS0RE", "DRI000EDERS0RE", TestName = "TC-10015", Description = "Alternative scenario test ,  increment ,string without number tail  ")]

        [TestCase("DRI000EDERS0RE99999", "DRI000EDERS0RE00000", TestName = "TC-10016", Description = "Main scenario test ,  main scenario test ,  increment ,string with prefix overflow occurs, Prefix with numbers  ")]
        
        [TestCase("18446744073709551615", "18446744073709551616", TestName = "TC-10017", Description = "Main scenario test ,  main scenario test ,  increment ,string with number more than nuint.MaxValue")]

        public void Test1(string inp  ,string expectedOutput)
        {
            var ret = incrementor.Increment(inp.ToCharArray());
            Assert.AreEqual(expectedOutput.ToCharArray(), ret,$"try to increment {inp} , expected recieve {expectedOutput} but recive {new string(ret)} - Failed");
            
        }

    }
}