using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //Verifíca si cambiamos o no de escena
    public bool CambioDeEscena;
    public int indiceDeNivel;
    // Start is called before the first frame update
    void Update()
    {
        if (CambioDeEscena)
        {
            CambiarEscena(indiceDeNivel);
        }
    }

    // Update is called once per frame
   public void CambiarEscena(int indice)
    {
        //Esto cambia la escena según el índice con el que se haya especificado en el inspector
        SceneManager.LoadScene(indice);
    }
}
