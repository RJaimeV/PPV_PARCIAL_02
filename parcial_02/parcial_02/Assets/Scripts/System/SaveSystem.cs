using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        else
        {

            instance = this;
        }
    }

    public void CreateFile(string _name, string _extension)
    {
        //1.- Definir el path del archivo
        string path = Application.dataPath + "/" + _name + _extension;
        //2.- Revisamos si el archivo en el path NO existe
        if (!File.Exists(path))
        {
            //3.- Creamos el contenido
            string content = "LOGIN DATE: " + System.DateTime.Now + "\n";
            //4.- Almacenamos la información
            File.AppendAllText(path, content);
        }
        else
        {
            Debug.LogWarning("Atención: Estas tratando de  crear un archivo con el nombre [" + _name + _extension + "], verifica tu información");
        }
        
    }

    private void Start()
    {
        //SaveToJSON("LecciónDummy", data);
        //SaveToJSON("SubjectDummy", subject);

        CreateFile("Panfilo", ".data");
        //Subject = LoadFromJSON<SubjectContainer>
    }
}