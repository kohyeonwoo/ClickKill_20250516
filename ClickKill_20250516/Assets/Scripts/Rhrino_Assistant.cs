using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Rhrino_Assistant : MonoBehaviour
{
    public Transform center;

    private NavMeshAgent nav;

    private Animator anim;

    private Rigidbody rigid;

    public float moveRange;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();

        rigid = GetComponent<Rigidbody>();

        center = GameObject.FindGameObjectWithTag("Center").transform;
    }

    private void Update()
    {
        if (nav.remainingDistance <= nav.stoppingDistance)
        {
            Vector3 point;

            if (RandomPoint(center.position, moveRange, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);

                nav.SetDestination(point);

                anim.SetBool("bMove", true);
            }

        }
    }


    bool RandomPoint(Vector3 Center, float Range, out Vector3 Result)
    {
        Vector3 randomPoint = Center + Random.insideUnitSphere * Range;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            Result = hit.position;

            return true;
        }

        Result = Vector3.zero;

        return false;
    }
}
