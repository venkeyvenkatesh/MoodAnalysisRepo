using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApplication;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_Happy_Returned_Happy()
        {
            string message = "Iam happy today";
            string expected = "happy";

            MoodAnalyser obj = new MoodAnalyser(message);
            string actual = obj.AnalyseMood();

            Assert.AreEqual(expected, actual);


        }

      
    }
}
