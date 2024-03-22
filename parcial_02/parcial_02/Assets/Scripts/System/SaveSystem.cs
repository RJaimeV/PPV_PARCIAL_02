using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    public Leccion data;
    public SubjectContainer subject;

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
            string position = "x: " + gameObject.transform.position.x + ", y: " + gameObject.transform.position.y;
            //4.- Almacenamos la información
            File.AppendAllText(path, position);
        }
        else
        {
            Debug.LogWarning("Atención: Estas tratando de  crear un archivo con el nombre [" + _name + _extension + "], verifica tu información");
        }
        
    }

    private void Start()
    {
        SaveToJSON("LecciónDummy", data);
        //SaveToJSON("SubjectDummy", subject);

        CreateFile("Panfilo", ".data");

        subject = LoadFromJSON<SubjectContainer>("preguntas");

        //Debug.Log(ReadFile("Panfilo", ".data"));

    }

    public string ReadFile(string _fileName, string _extension)
    {
        //1.- Acceder al path del archivo
        string path = Application.dataPath + "/Resources/" + _fileName + _extension;
        //2.- Si el archivo existe, dame su info
        string data = "";
        if (File.Exists(path))
        {
            data = File.ReadAllText(path);
        }
        return data;
    }

    public void SaveToJSON(string _fileName, object _data)
    {
        if (_data != null)
        {
            string JSONData = JsonUtility.ToJson(_data, true);
            if(JSONData.Length !=0)
            {
                Debug.Log("JSON STRING: " + JSONData);
                string fileName = _fileName + ".json";
                string filePath = Path.Combine(Application.dataPath + "/Resources/JSON/", fileName);
                File.WriteAllText(filePath, JSONData);
                Debug.Log("JSON almacenando en la dirección: " + filePath);
            }
            else
            {
                Debug.LogWarning("ERROR - fileSystem: JSONData is empty, check for local variable [string JSONData]");
            }
        }
        else
        {
            Debug.LogWarning("ERROR - FileSystem: _data is null, check for param [object _data]");
        }
        
    }

    public T LoadFromJSON<T>(string _fileName) where T : new()
    {
        T Data = new T();       
        string path = Application.dataPath + "/Resources/JSON/" + _fileName + ".json";       
        string JSONData = "";
        if (File.Exists(path))
        {
            JSONData = File.ReadAllText(path);
            Debug.Log("JSON STRING: " + JSONData);
        }

        if (JSONData.Length != 0)
        {
            JsonUtility.FromJsonOverwrite(JSONData, Data);
        }

        else
        {
            Debug.LogWarning("ERROR - FileSystem: JSONData is empty, check for local variable [dtring JSONData]");
        }
        return Data;
    }
}
