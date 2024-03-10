using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level Data")]
    public ScriptableObject Lesson;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string Question;
    public string correctAnswer;
    // Start is called before the first frame update
    void Start()
    {
        questionAmount = Lesson.leccionlist.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
