using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApplication;
using System.Security.Cryptography.X509Certificates;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        //UC1
        [TestMethod]
        public void Given_Happy_Returned_Happy()
        {
            string message = "Iam happy today";
            string expected = "happy";

            MoodAnalyser obj = new MoodAnalyser(message);
            string actual = obj.AnalyseMood();

            Assert.AreEqual(expected, actual);


        }

        //UC2
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
        //UC3
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

        //UC5
        
        [TestMethod]
        public void GivenMoodAnalyseClassName_ReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyser("happy");
            object actual = MoodAnalyserFactory.CreateMoodAnalysisUsingParamsCtor("MoodAnalyserApplication.MoodAnalyser", "MoodAnalyser","happy");

            expected.Equals(actual);
        }


        [TestMethod]
        public void GivenImproperMoodAnalyseClassName_ThrowNoSuchClassException()
        {
            // object expected = new MoodAnalyser("happy");

            MoodAnalysisException.ExceptionType expected = MoodAnalysisException.ExceptionType.NO_SUCH_CLASS;
            try
            {
                MoodAnalyserFactory.CreateMoodAnalysisUsingParamsCtor("MoodAnalyserApplication.Mood", "MoodAnalyser", "happy");
            }
           catch(MoodAnalysisException mae)
            {
                Assert.AreEqual(expected, mae.type);
            }
           
        }


        [TestMethod]
        public void GivenImproperMoodAnalyseCtorName_ThrowNoSuchMethodException()
        {
            

            MoodAnalysisException.ExceptionType expected = MoodAnalysisException.ExceptionType.NO_SUCH_METHOD;
            try
            {
                MoodAnalyserFactory.CreateMoodAnalysisUsingParamsCtor("MoodAnalyserApplication.MoodAnalyser", "Mood", "happy");
            }
            catch (MoodAnalysisException mae)
            {
                Assert.AreEqual(expected, mae.type);
            }

        }


        //UC6
        [TestMethod]
        public void GivenMoodAnalyseClassNameAndMethod_InvokeMethod()
        {
            string expected = "happy";
            string actual = MoodAnalyserFactory.InvokeAnalyseMoodMethod("Iam so happy today", "AnalyseMood");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
       public void GivenImproperMethodName_ThrowNoSuchMethodException()
        { 
          

            MoodAnalysisException.ExceptionType expected = MoodAnalysisException.ExceptionType.NO_SUCH_METHOD;
            try
            {
                MoodAnalyserFactory.InvokeAnalyseMoodMethod("Iam so happy today", "Analyse");
            }
            catch (MoodAnalysisException mae)
            {
                Assert.AreEqual(expected, mae.type);
            }

        }


        //UC7
        [TestMethod]
        public void GivenMessageDynamically_returnMessage()
        {
            string expected = "Iam happy today";
           

            string actual = MoodAnalyserFactory.SetField("Iam happy today","message");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GivenImproperFieldName_ThrowNoSuchFieldException()
        {


            MoodAnalysisException.ExceptionType expected = MoodAnalysisException.ExceptionType.NO_SUCH_FIELD;
            try
            {
                MoodAnalyserFactory.SetField("Iam so happy today", "mess");
            }
            catch (MoodAnalysisException mae)
            {
                Assert.AreEqual(expected, mae.type);
            }

        }


    }
}
