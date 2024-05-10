using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject retrypanel;
    public GameObject continuepanel;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI RetryText;
    public TextMeshProUGUI ContinueText;


    //public int sceneBuildIndex;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = QnA.Count;
        retrypanel.SetActive(false);
        continuepanel.SetActive(false);
        QuizPanel.SetActive(true);
        generateQuestion();

    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        SceneManager.LoadScene("Ending");
    }



    public void GameOver()
    {
        if (score == 4)
        {
            continuepanel.SetActive(true);
            QuizPanel.SetActive(false);
        }

        else
        {
            retrypanel.SetActive(true);
            QuizPanel.SetActive(false);
        }

    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        score -= 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<NewBehaviourScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<NewBehaviourScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions!");
            GameOver();
        }
    }
}
