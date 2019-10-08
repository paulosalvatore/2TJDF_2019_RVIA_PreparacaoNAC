using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 1f;

    public float velocidadeRotacao = 100f;

    private void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        transform.Translate(
            Vector3.forward * v * velocidade * Time.deltaTime
        );

        transform.Rotate(
            Vector3.up * h * velocidadeRotacao * Time.deltaTime
        );
    }
}