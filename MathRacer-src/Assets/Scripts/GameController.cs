using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text questionText;
    public TextMeshProUGUI answerText1, answerText2;
    public TMP_Text scoreText; // Texto para mostrar el puntaje
    public GameObject victoryPanel; // Panel de victoria
    public GameObject lossPanel; // Panel de pérdida
    public GameObject audioObject; // Asigna el objeto con el componente AudioSource aquí desde el Inspector de Unity
    private int correctAnswer;
    private int incorrectAnswer;
    private int questionCount = 0;
    private int correctCount = 0; // Contador de respuestas correctas
    private int penaltyCount = 0; // Contador de penalizaciones
    private Vector3 initialAnswer1Position;
    private Vector3 initialAnswer2Position;
    private Rect canvasBounds;
    private Vector2 canvasSize = new Vector2(1920f, 1080f);
    private List<string> usedQuestions = new List<string>(); // Almacena preguntas ya utilizadas
    private bool gameInProgress = true; // Controla si el juego está en progreso

    private float resetYPosition = -412.3f; // Nueva altura para el reinicio

    private int penaltyThreshold = 3; // Límite de penalizaciones para terminar el juego
    private int scorePenalty = 10; // Cantidad de puntos a restar por penalización
    private int scorePenaltyCount = 0; // Contador de penalizaciones al puntaje

    void Start()
    {
        initialAnswer1Position = answerText1.transform.position;
        initialAnswer2Position = answerText2.transform.position;

        questionText.gameObject.SetActive(false);
        answerText1.gameObject.SetActive(false);
        answerText2.gameObject.SetActive(false);
        victoryPanel.SetActive(false); // Oculta el panel de victoria al inicio
        lossPanel.SetActive(false); // Oculta el panel de pérdida al inicio

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
            SubtractPenaltyFromScore(); // Resta la penalización del puntaje
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
                int num1 = Random.Range(1, 101);
                int num2 = Random.Range(1, 101);
                correctAnswer = num1 + num2;
                incorrectAnswer = correctAnswer + Random.Range(1, 10);

                newQuestion = "¿" + num1 + " + " + num2 + "?";
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
            answerText2.gameObject.SetActive (true);

            questionCount++;
        }
        else if (gameInProgress)
        {
            gameInProgress = false;
            questionText.gameObject.SetActive(false);
            answerText1.gameObject.SetActive(false);
            answerText2.gameObject.SetActive(false);

            if (questionCount == 10) // Si se completan las 10 preguntas, muestra el panel de victoria
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
            penaltyCount = 0; // Reinicia el contador de penalizaciones
        }
        else
        {
            penaltyCount++;
            SubtractPenaltyFromScore(); // Resta la penalización del puntaje en respuesta incorrecta o penalización
        }

        UpdateScoreText();

        questionText.gameObject.SetActive(false);
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

        // Agrega esta línea para desactivar el objeto de audio
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
        // Aquí puedes mostrar un mensaje de fin de juego o realizar otra acción al finalizar el juego.
    }

    void ShowVictoryPanel()
    {
        // Muestra el panel de victoria
        victoryPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void ShowLossPanel()
    {
        // Muestra el panel de pérdida
        lossPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
