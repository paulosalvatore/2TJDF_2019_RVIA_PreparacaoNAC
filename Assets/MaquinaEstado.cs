using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaEstado : MonoBehaviour
{
    public enum Estados
    {
        Esperar,
        Patrulhar,
        Perseguir
    }

    private Estados estadoAtual;

    // Esperar
    public float tempoEsperar = 2f;
    private float tempoEsperando;

    // Patrulhar
    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;
    private Transform waypointAtual;
    public float distanciaMinimaWaypoint = 1.5f;
    private float distanciaWaypointAtual;

    // Perseguir
    public float distanciaMinimaPerserguicao = 5f;
    private float distanciaAtualPlayer;
    private GameObject player;

    private void Start()
    {
    }

    private void Update()
    {
    }
}