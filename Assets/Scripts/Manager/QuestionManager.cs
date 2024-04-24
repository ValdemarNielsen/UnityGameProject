using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Manager
{
    internal class QuestionManager
    {
        private HashSet<string> _questions;
        private List<string> _usedQuestions;
        private IQuestionGenerator _generator;
        private int _initialPoolSize;

        public QuestionManager(IQuestionGenerator initialGenerator, int initialPoolSize = 50)
        {
            _generator = initialGenerator;
            _initialPoolSize = initialPoolSize;
            _questions = new HashSet<string>();
            _usedQuestions = new List<string>();
            PopulateQuestionPool();
        }

        public void SetGenerator(IQuestionGenerator newGenerator)
        {
            _generator = newGenerator;
            ResetPool();
        }

        private void PopulateQuestionPool()
        {
            _questions.Clear();
            _usedQuestions.Clear();
            while (_questions.Count < _initialPoolSize)
            {
                var question = _generator.GenerateQuestion();
                _questions.Add(question);
            }
        }

        public string GetUniqueQuestionWithOptions(out List<string> options)
        {
            if (_questions.Count == 0)
            {
                Console.WriteLine("Out of unique questions! Repopulating...");
                PopulateQuestionPool();
            }

            var question = _questions.FirstOrDefault();
            options = _generator.GenerateOptions();
            _questions.Remove(question);
            _usedQuestions.Add(question);
            return question;
        }

        public void ResetPool()
        {
            PopulateQuestionPool();
        }
    }
}
