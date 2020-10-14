using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApplication;
using System.Security.Cryptography.X509Certificates;

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

        [TestMethod]
        public void Given_NULL_Throws_EXCEPTION()
        {
            string expected = "string should not be null";
            string message = null;

            try
            {
                MoodAnalyser obj = new MoodAnalyser(message);
                obj.AnalyseMood();
            }
            catch (MoodAnalysisException mae)
            {
                string actual = mae.Message;

                Assert.AreEqual(expected, actual);

            }
        }
        [TestMethod]
        public void Given_EmptyString_Throws_EXCEPTION()
        {

            string message = "";

            MoodAnalysisException.ExceptionType expected = MoodAnalysisException.ExceptionType.ENTERED_EMPTY;
            try
            {
                MoodAnalyser obj = new MoodAnalyser(message);
                obj.AnalyseMood();
            }
            catch (MoodAnalysisException mae)
            {

                Assert.AreEqual(expected, mae.type);

            }
        }


        [TestMethod]
        public void GivenMoodAnalyseClassName_ReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyser("happy");
            object actual = MoodAnalyserFactory.CreateMoodAnalysisUsingParamsCtor("MoodAnalyserApplication.MoodAnalyser", "MoodAnalyser","happy");

            expected.Equals(actual);
        }
    }
}
