using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kamikaze : MonoBehaviour
{
    private GameObject player;

    public NavMeshAgent navMeshAgent;

    public float distanciaMinima = 2f;

    private float distanciaAtual;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Kamikaze irá seguir o Player
        navMeshAgent.destination = player.transform.position;

        // Atualiza a distância entre o Kamikaze e o Player
        distanciaAtual =
            Vector3.Distance(
                transform.position,
                player.transform.position
            );

        // Se estiver perto suficiente, destrói
        if (distanciaAtual <= distanciaMinima)
        {
            Destroy(gameObject);
        }
    }
}