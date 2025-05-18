using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Bear_Assistant : Assistant
{

    private NavMeshAgent agent;

    public GameObject playerAttackCollision;

    public Transform target;

    public float range;

    [SerializeField]
    private string targetTag = "Enemy";

    private void Start()
    {
        Init();

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        UpdateTarget();

        if (target == null)
        {
            return;
        }
       
    }

    public void ActiveAttackCollision()
    {
        playerAttackCollision.SetActive(true);
    }

    public void DeActiveAttackCollision()
    {
        playerAttackCollision.SetActive(false);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);

        float shortestDistance = Mathf.Infinity; //�� ���� �����Ǿ� ���� ���� ���

        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,
                enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;

                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

}
