using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Bear_Assistant : Assistant
{

    private NavMeshAgent agent;

    public GameObject playerAttackCollision;

    private void Start()
    {
        Init();

        agent = GetComponent<NavMeshAgent>();
    }

    public void ActiveAttackCollision()
    {
        playerAttackCollision.SetActive(true);
    }

    public void DeActiveAttackCollision()
    {
        playerAttackCollision.SetActive(false);
    }

}
