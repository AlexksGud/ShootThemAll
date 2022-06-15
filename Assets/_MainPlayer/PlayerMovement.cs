using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    private NavMeshAgent nmagent;

    [SerializeField] private PointContainer pointContainer;

    [SerializeField] private Animator _animator;


    void Start()
    {
        nmagent = GetComponent<NavMeshAgent>();
    }

    public void MoveNextPoint()
    {

        nmagent.SetDestination(pointContainer.NextPoint());
    }
}
