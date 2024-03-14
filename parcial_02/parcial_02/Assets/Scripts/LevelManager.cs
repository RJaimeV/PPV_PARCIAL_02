using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    //Instancia de la clase
    public static LevelManager Instance;

    [Header("Level Data")]
    public Subject Lesson;

    [Header("Use Interface")]
    public TMP_Text QuestionTxt;
    public TMP_Text LivesTxt;
    public List<Option> Options;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer = 9;
    public int lives = 5;

    [Header("Current lesson")]
    public Leccion currentLesson;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Establecemos la cantidad de preguntas en la lección
        questionAmount = Lesson.leccionList.Count;
        //Cargar la primera pregunta
        LoadQuestion();
        //Check player input
        CheckPlayerState();
    }

    // Update is called once per frame
    private void LoadQuestion()
    {
        //Aseguramos que la pregunta actual este dentro de los límites
        if (currentQuestion < questionAmount)
        {
            //Establecemos la lección actual
            currentLesson = Lesson.leccionList[currentQuestion];
            //Establecemos la pregunta
            question = currentLesson.lessons;
            //Establecemos la respuesta correcta
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];
            //Establecemos la pregunta en UI
            QuestionTxt.text = question;

            for (int i = 0; i < currentLesson.options.Count; i++)
            {
                Options[i].GetComponent<Option>().OptionName = currentLesson.options[i];
                Options[i].GetComponent<Option>().OptionID = i;
                Options[i].GetComponent<Option>().UpdateText();
            }
        }
        else
        {
            //Si llegamos al final de las preguntas
            Debug.Log("Fin de las preguntas");
        }
    }
    public void NextQuestion()
    {
        //Revisamos si el jugador presiono
        if (CheckPlayerState())
        {
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la respuesta es correcta o no
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                AnswerContainer.SetActive(true);

                if (isCorrect)
                {
                    AnswerContainer.GetComponent<Image>().color = Green;
                    Debug.Log("Respuesta correcta." + question + ": " + correctAnswer);
                }
                else
                {
                    lives--;
                    AnswerContainer.GetComponent<Image>().color = Red;
                    Debug.Log("Respuesta Incorrecta." + question + ": " + correctAnswer);
                }

                // Actualizamos el contador de vida
                LivesTxt.text = lives.ToString();

                // Incrementamos el indice de la pregunta actual
                currentQuestion++;

                // Mostrar el resultado durante un tiempo (puedes usar una courotine o Invoke) y cargar pregunta
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));  

                //Resetear AnswerfromPlayer
                answerFromPlayer = 9;

            }
            else
            {
                //Cambio de escena
            }
        }
    }

    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        yield return new WaitForSeconds(2.5f); // Ajusta el tiempo que deseas mostrar el resultado

        //Ocultar el contenedor de respuestas
        AnswerContainer.SetActive(false);

        //Carga la nueva pregunta
        LoadQuestion();

        // Activar el botón después de mostrar el resultado
        // Puedes hacer esto aquí o en LoadQuestion(), dependiendo de tu estructura
        // por ejemplo: si el botón está en el mismo GameObject que el script (GetComponent<Button>().interactable = true;
        CheckPlayerState();
    }
    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    public bool CheckPlayerState()
    {
        if (answerFromPlayer != 9)
        {
            //Si el jugador interactuo
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            //Si el jugador no interactuo
            CheckButton.GetComponent<Button>().interactable = false;
            CheckButton.GetComponent<Image>().color = Color.gray;
            return false;
        }
    }
}
