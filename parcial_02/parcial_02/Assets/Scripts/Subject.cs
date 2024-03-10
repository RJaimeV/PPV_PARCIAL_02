using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Subject", menuName = "ScriptableObjects/NewLesson", order = 1)]

public class Subject : ScriptableObject
{
    [Header("GameObject Configuration")]
    public int Lesson = 0;

    [Header("Lesson Quest Configuration")]
    public List<Leccion> leccionList;
}
