using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Services;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.UI
{
    public class QuestionUI : MonoBehaviour
    {
        public Text questionDisplayText;
        public InputField answerInput;
        public Button submitButton;
        private BasicMathGenerator questionGenerator;
        private string currentAnswer;

        void Start()
        {
            questionGenerator = new BasicMathGenerator();
            GenerateNewQuestion();
            submitButton.onClick.AddListener(CheckAnswer);
        }

        void GenerateNewQuestion()
        {
            string question = questionGenerator.GenerateQuestion();
            questionDisplayText.text = question;
            currentAnswer = questionGenerator.CorrectAnswer;
            answerInput.text = "";  // Clear previous answer
        }

        void CheckAnswer()
        {
            if (answerInput.text == currentAnswer)
            {
                Debug.Log("Correct!");
                if (GameManager.pointScore == 15)
                {
                    Debug.Log("You have won good job");
                    SceneManager.LoadScene("WinScene");
                }
                else 
                {
                    GameManager.pointScore++;
                    SceneManager.LoadScene(GameManager.sceneName);
                }
                
            }
            else
            {
                Debug.Log("Incorrect! Correct answer was: " + currentAnswer);
            }
            GenerateNewQuestion(); // Generate new question regardless of whether the answer was correct or not
        }
    }
}
