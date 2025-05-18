using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Tornado_Assistant : MonoBehaviour
{

    public Transform center;

    private NavMeshAgent nav;

    public float moveRange;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();

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
