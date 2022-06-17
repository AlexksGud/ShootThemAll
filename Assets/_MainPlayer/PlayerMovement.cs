using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    private NavMeshAgent nmagent;

    [SerializeField] private PointContainer _pointContainer;
    [SerializeField] private Animator _animator;


     public float speed { get; private set; }


    void Start()
    {
        nmagent = GetComponent<NavMeshAgent>();
        StartCoroutine(CalculateSpeed());
    }

    public void MoveNextPoint()
    {
        nmagent.SetDestination(_pointContainer.NextPoint());

    }
    private void FixedUpdate()
    {
        _animator.SetFloat("Velocity", speed);
    }

    IEnumerator CalculateSpeed()
    {
        while (true)
        {
            Vector3 prePosition = transform.position;
            yield return new WaitForFixedUpdate();

            speed = Vector3.Distance
                (transform.position, prePosition) / Time.fixedDeltaTime;


        }
    }

    public void ShootAnimation()
    {
        _animator.SetTrigger("Fire");
    }
}
