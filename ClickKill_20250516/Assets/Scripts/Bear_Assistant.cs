using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Bear_Assistant : Assistant
{

    private NavMeshAgent agent;

    private void Start()
    {
        Init();

        agent = GetComponent<NavMeshAgent>();
    }
}
