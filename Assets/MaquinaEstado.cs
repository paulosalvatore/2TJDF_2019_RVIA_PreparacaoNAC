using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MaquinaEstado : MonoBehaviour
{
    public enum Estados
    {
        Esperar,
        Patrulhar,
        Perseguir
    }

    private Estados estadoAtual;

    public NavMeshAgent navMeshAgent;

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
    public float distanciaMinimaPerseguicao = 5f;
    private float distanciaAtualPlayer;
    private GameObject player;

    private Transform target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        waypointAtual = waypoint1;

        Esperar();
    }

    private void Esperar()
    {
        estadoAtual = Estados.Esperar;
        tempoEsperando = Time.time;
    }

    private void Update()
    {
        if (PossuiVisaoJogador())
        {
            Perseguir();
        }

        switch (estadoAtual)
        {
            case Estados.Esperar:
                target = transform;

                if (EsperouTempoSuficiente())
                {
                    Patrulhar();
                }

                break;
            case Estados.Patrulhar:
                target = waypointAtual;

                if (PertoWaypointAtual())
                {
                    AlterarWaypoint();
                }

                break;
            case Estados.Perseguir:
                target = player.transform;

                if (!PossuiVisaoJogador())
                {
                    Esperar();
                }

                break;
        }

        //if (target != null)
        //{
        //    navMeshAgent.destination = target.position;
        //}

        navMeshAgent.destination = target?.position ?? navMeshAgent.destination;
    }

    private void Perseguir()
    {
        estadoAtual = Estados.Perseguir;
    }

    private bool PossuiVisaoJogador()
    {
        distanciaAtualPlayer = Vector3.Distance(
            transform.position,
            player.transform.position
        );

        return distanciaAtualPlayer <= distanciaMinimaPerseguicao;
    }

    private void AlterarWaypoint()
    {
        if (waypointAtual == waypoint1)
        {
            waypointAtual = waypoint2;
        }
        else if (waypointAtual == waypoint2)
        {
            waypointAtual = waypoint3;
        }
        else if (waypointAtual == waypoint3)
        {
            waypointAtual = waypoint1;
        }
    }

    private bool PertoWaypointAtual()
    {
        distanciaWaypointAtual = Vector3.Distance(
            transform.position,
            waypointAtual.position
        );

        return distanciaWaypointAtual <= distanciaMinimaWaypoint;
    }

    private void Patrulhar()
    {
        estadoAtual = Estados.Patrulhar;
    }

    private bool EsperouTempoSuficiente()
    {
        return tempoEsperando + tempoEsperar <= Time.time;
    }
}