using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ScriptError : MonoBehaviour
{
    public float velocidad = 5f;
    Vector3 movimiento;

    private void Update()
    {
        //Obtener la entrada del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientovertical = Input.GetAxis("vertical");

        //Calcular el vector de movimiento
        //Vector3 movimiento = new Vector3 (movimientoHorizontal, 0f, movimientoVertical);
        movimiento = new Vector3(movimientoHorizontal, movimientovertical, 0f);

        //Mover el objeto en la dirección calculada
        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.World);
    }
}
