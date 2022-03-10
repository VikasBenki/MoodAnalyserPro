using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserPro;
using System;

namespace AnalyzeMoodTest
{
    [TestClass]
    public class AnalyzeMoodTestCases
    {
        //Method to test Sad Mood
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

        //Method to test Happy Mood
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

        //Method to test Happy Mood in null message
        [TestMethod]
        [TestCategory("Null Exception")]
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
    }
}
