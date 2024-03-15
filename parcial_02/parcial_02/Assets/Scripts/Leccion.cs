using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Leccion
{
    //Contenido del scriptableObject
    public int ID;
    public string lessons;
    public List<string> options;
    public int correctAnswer;
}
