using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserPro;
using MoodAnalyserPro.Reflection;
using System;

namespace AnalyzeMoodTest
{
    [TestClass]
    public class AnalyseMoodTestCases
    {
        MoodAnalyserFactory factory;
        [TestInitialize]
        public void Setup()
        {
            factory = new MoodAnalyserFactory();
        }

        //TC 1.1 - Method to test Sad Mood
        [TestMethod]
        [TestCategory("Sad Message")]
        public void TestSadMoodInMessage()
        {
            //Arrange
            string message = "I am in sad Mood";
            string expected = "SAD";
            AnalyzeMood analyse = new AnalyzeMood(message);

            //Act
            string actual = analyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //TC 1.2 - Method to test Happy Mood
        [TestMethod]
        [TestCategory("Happy Message")]
        public void TestHappyMoodInMessage()
        {
            //Arrange
            string message = "I am in Any Mood";
            string expected = "HAPPY";
            AnalyzeMood analyse = new AnalyzeMood(message);

            //Act
            string actual = analyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //TC 2.1 - Method to test Happy Mood in null message
        [TestMethod]
        [TestCategory("Exception")]
        public void GivenNullMessageReturnHappyMood()
        {
            //Arrange
            string message = null;
            string expected = "HAPPY";
            AnalyzeMood analyse = new AnalyzeMood(message);

            //Act
            string actual = analyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //TC 3.1 - Method to test Custom exception for null message
        [TestMethod]
        [TestCategory("Custom Exception")]
        [DataRow(null, "Message should not be null")]
        [DataRow("", "Message should not be empty")]
        public void GivenNullMessageTestCustomException(string userInput, string expected)
        {
            //Arrange
            //string message = null;
            //string expected = "HAPPY";
            AnalyzeMood analyse = new AnalyzeMood(userInput);
            try
            {
                //Act
                string actual = analyse.AnalyseMood();
            }
            catch (MoodAnalyserException ex)
            {
                //Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        //TC 4.1 - Proper class details are provided and expected to return the MoodAnalyser Object
        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyserPro.Reflection.Customer", "Customer")]
        public void GivenAnalyzeMoodClassName_ReturnAnalyzeMoodObject(string className, string constructorName)
        {
            AnalyzeMood expected = new AnalyzeMood();
            object obj = null;

            MoodAnalyserFactory factory = new MoodAnalyserFactory();
            obj = factory.CreateMoodMoodAnalyse(className, constructorName);
            expected.Equals(obj);
        }

        //TC 4.2 - improper class details are provided and expected to throw exception Class not found
        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyserPro.Reflection.Owner", "Reflection.Owner", "Class not found")]
        public void GivenImproperClassName_ThrowException(string className, string constructorName, string expected)
        {
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object actual = factory.CreateMoodMoodAnalyse(className, constructorName);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        //TC 4.3 - improper constructor details are provided and expected to throw exception Constructor not found
        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyserProblem.Reflection.Customer", "Reflection.OwnerMood", "Constructor not found")]
        public void GivenImproperConstructorName_ThrowException(string className, string constructorName, string expected)
        {
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object actual = factory.CreateMoodMoodAnalyse(className, constructorName);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //TC 5.1 - Method to test moodanalyser class with parameter constructor to check if two objects are equal
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("I am in Happy mood")]
        [DataRow("I am in Sad mood")]
        [DataRow("I am in any mood")]
        public void GivenMessageReturnParameterizedConstructor(string message)
        {
            AnalyzeMood expected = new AnalyzeMood(message);
            object obj = null;
            try
            {
                obj = factory.CreateMoodMoodAnalyserParameterObject("AnalyzeMood", "AnalyzeMood", message);
            }
            catch (MoodAnalyserException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
            obj.Equals(expected);
        }

        //TC 5.2 - Method to test moodanalyser with diff class with parameter constructor to throw error
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("Company", "I am in Happy mood", "Could not find class")]
        [DataRow("Student", "I am in Sad mood", "Could not find class")]
        public void GivenMessageReturnParameterizedClassNotFound(string className, string message, string expextedError)
        {
            AnalyzeMood expected = new AnalyzeMood(message);
            object obj = null;
            try
            {
                obj = factory.CreateMoodMoodAnalyserParameterObject(className, "MoodAnalyzer", message);

            }
            catch (MoodAnalyserException actual)
            {
                Assert.AreEqual(expextedError, actual.Message);
            }
        }

        //TC 5.3 - Method to test moodanalyser with diff constructor with parameter constructor to throw error
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("Customer", "I am in Happy mood", "Could not find constructor")]
        [DataRow("Student", "I am in Sad mood", "Could not find constructor")]
        public void GivenMessageReturnParameterizedConstructorNotFound(string constructor, string message, string expextedError)
        {
            AnalyzeMood expected = new AnalyzeMood(message);
            object obj = null;
            try
            {
                obj = factory.CreateMoodMoodAnalyserParameterObject("AnalyzeMood", constructor, message);

            }
            catch (MoodAnalyserException actual)
            {
                Assert.AreEqual(expextedError, actual.Message);
            }
        }
        //UC 6.1,6.2 - Method to invoke analyse mood method to return happy or sad or invalid method
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("HAPPY")]
        [DataRow("Method not found")]
        public void ReflectionReturnMethod(string expected)
        {
            try
            {
                string actual = factory.InvokeAnalyzeMood("happy", "AnalyseMood");
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}

