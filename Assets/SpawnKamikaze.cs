using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKamikaze : MonoBehaviour
{
    public GameObject kamikazePrefab;

    public float delay = 2.5f;

    private void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
    }

    private void Spawn()
    {
        var instancia = Instantiate(kamikazePrefab);

        var posicao = transform.position;
        posicao.y = instancia.transform.position.y;

        instancia.transform.position = posicao;
    }
}