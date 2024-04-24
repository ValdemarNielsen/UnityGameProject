using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // If using TextMeshPro
using Assets.Scripts.Services;
using Assets.Scripts.Manager;

namespace Assets.Scripts.UI
{
    public class QuestionUI : MonoBehaviour
    {
        public TMP_Text questionText;  // For TextMeshPro use TMP_Text instead of Text
        public Button[] optionButtons = new Button[4];

        private QuestionManager questionManager;

        void Start()
        {
            // Assuming BasicMathGenerator and QuestionManager are properly set up
            questionManager = new QuestionManager(new BasicMathGenerator(), 50);
            GenerateQuestion();
        }

        void GenerateQuestion()
        {
            List<string> options;
            string question = questionManager.GetUniqueQuestionWithOptions(out options);
            questionText.text = $"Solve the following: {question}";

            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].GetComponentInChildren<TMP_Text>().text = options[i]; // Ensure to use TMP_Text for TextMeshPro
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => OptionSelected(options[i]));
            }
        }

        void OptionSelected(string selectedOption)
        {
            if (selectedOption == questionManager.CurrentGenerator.CorrectAnswer)
            {
                Debug.Log("Correct!");
            }
            else
            {
                Debug.Log("Incorrect!");
            }
            GenerateQuestion();  // Generate a new question after an answer is selected
        }

    }
}
