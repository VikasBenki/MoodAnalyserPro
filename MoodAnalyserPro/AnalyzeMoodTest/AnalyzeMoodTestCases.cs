using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserPro;
using System;

namespace AnalyzeMoodTest
{
    [TestClass]
    public class AnalyzeMoodTestCases
    {
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
    }
}
