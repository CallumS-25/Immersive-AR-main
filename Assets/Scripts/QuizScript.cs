using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizScript : MonoBehaviour
{

    public TMP_Text question;
    public TMP_Text[] buttonText;
    public Button returnButton;

    public List<quizQuestions> questions = new List<quizQuestions>();
    
    int currentQuestion = 0; 
    int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateQuestion();
        returnButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetCurrentQuestion()
    {
        return currentQuestion;
    }

    public void answerClick(string answer)
    {
        if (answer[0] == questions[currentQuestion].answer)
        {
            score += 10;
            question.text = "Correct! You now got " + score.ToString() + " Points!";
        }
        else
        {
            question.text = "Incorrect... You are currently on " + score.ToString() + " Points.";
        }
        returnButton.interactable = true;
    }

    public void QuizCompleted()
    {
        //Hoping to be able to use this.
        //What I want to do for this is when the current question in the array of questions in the game has been answered correctly,
        //it marks the current question bool as Completed to which you cannot access it anymore, and you can return to the quiz menu and continue with the other questions
    }

    public void returnClick()
    {
        returnButton.interactable = false;
    }
    void updateQuestion()
    {
        question.text = questions[currentQuestion].Q;

        buttonText[0].text = questions[currentQuestion].A;
        buttonText[1].text = questions[currentQuestion].B;
        buttonText[2].text = questions[currentQuestion].C;
    }

    [System.Serializable]
    public class quizQuestions
    {
        public string Q;
        public string A;
        public string B;
        public string C;
        public char answer;
        public bool completed;
    }
}
