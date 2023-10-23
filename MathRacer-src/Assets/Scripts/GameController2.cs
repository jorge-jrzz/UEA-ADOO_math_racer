using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController2 : MonoBehaviour
{
    public TMP_Text questionText;
    public TextMeshProUGUI answerText1, answerText2;
    public TMP_Text scoreText;
    public GameObject victoryPanel;
    public GameObject lossPanel;
    public GameObject audioObject;
    private int correctAnswer;
    private int incorrectAnswer;
    private int questionCount = 0;
    private int correctCount = 0;
    private int penaltyCount = 0;
    private Vector3 initialAnswer1Position;
    private Vector3 initialAnswer2Position;
    private Rect canvasBounds;
    private Vector2 canvasSize = new Vector2(1920f, 1080f);
    private List<string> usedQuestions = new List<string>();
    private bool gameInProgress = true;
    private float resetYPosition = -412.3f;
    private int penaltyThreshold = 3;
    private int scorePenalty = 10;
    private int scorePenaltyCount = 0;

    void Start()
    {
        initialAnswer1Position = answerText1.transform.position;
        initialAnswer2Position = answerText2.transform.position;

        questionText.gameObject.SetActive(false);
        answerText1.gameObject.SetActive(false);
        answerText2.gameObject.SetActive(false);
        victoryPanel.SetActive(false);
        lossPanel.SetActive(false);

        GenerateQuestion();

        CalculateCanvasBounds();
    }

    void Update()
    {
        if (gameInProgress)
        {
            CheckTextMeshProPosition(answerText1);
            CheckTextMeshProPosition(answerText2);
        }
    }

    void CheckTextMeshProPosition(TextMeshProUGUI textMeshPro)
    {
        if (textMeshPro.transform.position.y <= resetYPosition || !IsWithinCanvasBounds(textMeshPro.transform.position))
        {
            ResetTextMeshProPosition(textMeshPro);
            ChangeQuestionAndAnswers();
            penaltyCount++;
            SubtractPenaltyFromScore();
        }
    }

    void GenerateQuestion()
    {
        if (gameInProgress && questionCount < 10)
        {
            questionText.gameObject.SetActive(true);
            questionText.text = "";

            ResetAnswerPositions();

            string newQuestion;
            do
            {
                int num1 = Random.Range(1, 61) * 5; // Numerador es un múltiplo de 5 entre 5 y 300
                int num2 = 5; // Denominador siempre 5

                correctAnswer = num1 / num2;
                int answerOffset = Random.Range(1, 10);
                incorrectAnswer = (num1 / num2) + answerOffset;

                newQuestion = "¿" + num1 + " / " + num2 + "?";
            }
            while (usedQuestions.Contains(newQuestion));

            usedQuestions.Add(newQuestion);
            questionText.text = newQuestion;

            if (Random.Range(0, 2) == 0)
            {
                answerText1.text = correctAnswer.ToString();
                answerText2.text = incorrectAnswer.ToString();
            }
            else
            {
                answerText2.text = correctAnswer.ToString();
                answerText1.text = incorrectAnswer.ToString();
            }

            answerText1.gameObject.SetActive(true);
            answerText2.gameObject.SetActive(true);

            questionCount++;
        }
        else if (gameInProgress)
        {
            gameInProgress = false;
            questionText.gameObject.SetActive(false);
            answerText1.gameObject.SetActive(false);
            answerText2.gameObject.SetActive(false);

            if (questionCount == 10)
            {
                ShowVictoryPanel();
            }
        }
    }

    public void Answer(int answer)
    {
        if (answer == correctAnswer)
        {
            correctCount += 10;
            penaltyCount = 0;
        }
        else
        {
            penaltyCount++;
            SubtractPenaltyFromScore();
        }

        UpdateScoreText();

        questionText.gameObject.SetActive (false);
        answerText1.gameObject.SetActive(false);
        answerText2.gameObject.SetActive(false);

        ChangeQuestionAndAnswers();
    }

    void ResetAnswerPositions()
    {
        answerText1.transform.position = initialAnswer1Position;
        answerText2.transform.position = initialAnswer2Position;
    }

    void ResetTextMeshProPosition(TextMeshProUGUI textMeshPro)
    {
        textMeshPro.transform.position = textMeshPro == answerText1 ? initialAnswer1Position : initialAnswer2Position;
    }

    void CalculateCanvasBounds()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            canvasBounds = new Rect(
                canvas.transform.position.x - canvasSize.x / 2,
                canvas.transform.position.y - canvasSize.y / 2,
                canvasSize.x,
                canvasSize.y);
        }
        else
        {
            Debug.LogError("No se encontró un objeto Canvas en la escena.");
        }
    }

    bool IsWithinCanvasBounds(Vector3 position)
    {
        return canvasBounds.Contains(position);
    }

    void ChangeQuestionAndAnswers()
    {
        if (gameInProgress)
        {
            GenerateQuestion();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Puntaje: " + correctCount;
    }

    void SubtractPenaltyFromScore()
    {
        correctCount -= scorePenalty;
        scorePenaltyCount++;

        if (scorePenaltyCount >= 3)
        {
            ShowLossPanel();

            if (audioObject != null)
            {
                audioObject.SetActive(false);
            }
        }

        UpdateScoreText();
    }

    void EndGame()
    {
        gameInProgress = false;
        questionText.gameObject.SetActive(false);
        answerText1.gameObject.SetActive(false);
        answerText2.gameObject.SetActive(false);
    }

    void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void ShowLossPanel()
    {
        lossPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
