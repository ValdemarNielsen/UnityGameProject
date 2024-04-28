using Assets.Scripts.Services;
using NUnit.Framework;
using System.Linq;
using System;
using System.Diagnostics;
using UnityEngine;

namespace GameProject.Tests
{
    [TestFixture]
    public class BasicMathGeneratorTests
    {
        private BasicMathGenerator mathGenerator;

        [SetUp]
        public void Initialize()
        {
            // Create a new instance of BasicMathGenerator before each test
            mathGenerator = new BasicMathGenerator();
        }

        [Test]
        public void QuestionFormat_ShouldBeCorrect()
        {
            // Generate a math question
            string question = mathGenerator.GenerateQuestion();

            // Remove any extra whitespace from the question and ensure it ends with a '?'
            question = question.Trim();
            Assert.IsTrue(question.EndsWith("?"), "Question does not end with '?'.");
            
            // Split the question into parts, removing empty entries that may be caused by extra spaces
            string[] parts = question.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Check if the question contains a valid arithmetic operator
            bool hasOperator = parts.Contains("+") || parts.Contains("-") ||
                               parts.Contains("*") || parts.Contains("/");
            bool hasEquals = parts.Contains("=");
            Assert.IsTrue(hasOperator, "Question does not contain an operator.");

            // The question should consist of exactly three parts plus a '?': number, operator, number
            Assert.AreEqual(5, parts.Length, "Question should have three parts excluding the '?'.");
        }


        // Test to verify that the correct answer is computed properly
        [Test]
        public void CorrectAnswer_ShouldBeAccurate()
        {
            // Generate a question and retrieve its components
            string question = mathGenerator.GenerateQuestion();
            string[] parts = question.Split(' ');
            int number1 = int.Parse(parts[0]);
            int number2 = int.Parse(parts[2]);
            string operatorSymbol = parts[1];

            // Calculate the expected answer based on the operator
            int expectedAnswer = operatorSymbol switch
            {
                "+" => number1 + number2,
                "-" => number1 - number2,
                "*" => number1 * number2,
                "/" => number1 / number2,
                _ => 0
            };

            // Check if the CorrectAnswer property matches the expected answer
            Assert.AreEqual(expectedAnswer.ToString(), mathGenerator.CorrectAnswer,
                            "CorrectAnswer does not match expected result.");
        }

        // Test to ensure there's no division by zero
        [Test]
        public void DivisionByZero_ShouldNotHappen()
        {
            for (int i = 0; i < 100; i++)
            {
                // Generate a question
                string question = mathGenerator.GenerateQuestion();

                // Check if the question involves division
                if (question.Contains("/"))
                {
                    string[] parts = question.Split(' ');
                    int divisor = int.Parse(parts[2]);

                    // Assert that the divisor is not zero
                    Assert.AreNotEqual(0, divisor, "Divisor should not be zero.");
                }
            }
        }
    }
}
