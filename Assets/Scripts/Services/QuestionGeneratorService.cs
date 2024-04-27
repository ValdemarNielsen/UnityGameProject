﻿using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assets.Scripts.Services
{
    internal class QuestionGeneratorService
    {
        public enum AgeGroup
        {
            Children,
            Teenagers,
            Adults
        }
    }

    public class BasicMathGenerator : IQuestionGenerator
    {
        public string CorrectAnswer { get; private set; }
        private System.Random random = new System.Random();

        public string GenerateQuestion()
        {
            int a = random.Next(1, 10);
            int b = random.Next(1, 10);
            int operation = random.Next(0, 4); // Randomly choose an operation: 0, 1, 2, or 3

            switch (operation)
            {
                case 0: // Addition
                    CorrectAnswer = (a + b).ToString();
                    return $"{a} + {b} = ?";
                case 1: // Subtraction
                    CorrectAnswer = (a - b).ToString();
                    return $"{a} - {b} = ?";
                case 2: // Multiplication
                    CorrectAnswer = (a * b).ToString();
                    return $"{a} * {b} = ?";
                case 3: // Division, ensure no division by zero and a whole number result
                    b = b == 0 ? 1 : b; // Ensure b is not zero
                    a = a * b; // Adjust a so that the division result is a whole number
                    CorrectAnswer = (a / b).ToString();
                    return $"{a} / {b} = ?";
                default:
                    return "Invalid operation"; // Should never hit this case
            }
        }
    }

        public static class MathUtilities
    {
        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }
    }
    /*
    public class AlgebraGenerator : IQuestionGenerator
    {
        private System.Random random = new System.Random();

        public string GenerateQuestion()
        {
            int a = random.Next(1, 11);  // Coefficient of x, ensuring it's not zero
            int b = random.Next(-10, 11);  // Constant term, can be negative
            int c = random.Next(-10, 11);  // Right side of the equation, can be negative

            // Generate an equation ax + b = c
            string equation = $"{a}x + {b} = {c}";

            // Calculate the correct answer: (c - b) / a
            // Ensures answer is in simplest form, represented as a fraction if needed
            int numerator = c - b;
            int gcd = MathUtilities.GCD(Math.Abs(numerator), Math.Abs(a));  // Greatest common divisor for simplification
            int simplifiedNumerator = numerator / gcd;
            int simplifiedDenominator = a / gcd;

            if (simplifiedDenominator == 1)  // If denominator is 1, no need to show fraction
                CorrectAnswer = $"{simplifiedNumerator}";
            else if (simplifiedDenominator < 0)  // Handle negative denominator
            {
                simplifiedNumerator = -simplifiedNumerator;  // Move negativity to numerator
                simplifiedDenominator = -simplifiedDenominator;
                CorrectAnswer = simplifiedDenominator == 1 ? $"{simplifiedNumerator}" : $"{simplifiedNumerator}/{simplifiedDenominator}";
            }
            else
                CorrectAnswer = $"{simplifiedNumerator}/{simplifiedDenominator}";

            return equation;
        }

        public string CorrectAnswer { get; private set; }

    } */

    


}