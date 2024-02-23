using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LessonContainer : MonoBehaviour
{
    [Header("GamePbject Configuration")]
    public int Lection = 0;
    public int CurrentLesson = 0;
    public int TotalLessons = 0;
    public bool AreAllLessonsComplete = false;

    [Header("UI Configuration")]  
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;
    // Start is called before the first frame update
    void Start()
    {
        if (lessonContainer != null)
        {
            OnUpdateUI();
        }
        else
        {
            Debug.LogWarning("GameObject nulo, revisa las variables de tipo GameObject lessonContainer " + name);
        }
    }

    public void OnUpdateUI()
    {
        if (StageTitle != null || LessonStage != null )
        {
            StageTitle.text = "Leccion " + Lection;
            LessonStage.text = "Leccion " + CurrentLesson + " de " + TotalLessons;
        }
        else
        {
            Debug.LogWarning("GameObject nulo, revisa las variables de tipo TMP_Text");
        }
    }

    //Este metodo activa/desactiva la ventana de lessonConatines
    public void EnableWindow()
    {
        OnUpdateUI ();

        if (lessonContainer.activeSelf)
        {
            //Desactiva el objeto si está activo
            lessonContainer.SetActive(false);
        }
        else 
        {
            //Activa el objeto si está desactivado
            lessonContainer.SetActive (true);
        }
    }

}
