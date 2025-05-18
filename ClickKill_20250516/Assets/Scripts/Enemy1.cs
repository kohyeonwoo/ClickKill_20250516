using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IDamageable
{

    public GameObject currentCharacter;
    public GameObject regdollCharacter;

    public Transform center;

    public Rigidbody spine;

    public float maxHealth;
    public float currentHealth;

    public float moveRange;

    private NavMeshAgent nav;

    private Animator anim;

    private void Start()
    {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();

        nav = GetComponent<NavMeshAgent>();

        center = GameObject.FindGameObjectWithTag("Center").transform;
    }

    private void Update()
    {

        regdollCharacter.transform.position = currentCharacter.transform.position;

        regdollCharacter.transform.rotation = currentCharacter.transform.rotation;

        if (nav.remainingDistance <= nav.stoppingDistance)
        {
            Vector3 point;

             if(RandomPoint(center.position, moveRange, out point))
             {
                 Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);

                 anim.SetBool("bMove", true);

                 nav.SetDestination(point);  
             }

        }
    }

    bool RandomPoint(Vector3 Center, float Range, out Vector3 Result)
    {
        Vector3 randomPoint = Center + Random.insideUnitSphere * Range;

        NavMeshHit hit;

        if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            Result = hit.position;

            return true;
        }

        Result = Vector3.zero;

        return false;
    }

    public void ChangeCharacter()
    {
        CopyCharacterTransformToRegdoll(currentCharacter.transform, regdollCharacter.transform);

        currentCharacter.SetActive(false);
        regdollCharacter.SetActive(true);

        spine.AddForce(new Vector3(0.0f, 0.0f, 280.0f), ForceMode.Impulse);
    }

    private void CopyCharacterTransformToRegdoll(Transform origin, Transform regdoll)
    {
        for(int i = 0; i < origin.childCount; i++)
        {
            if(origin.childCount != 0)
            {
                CopyCharacterTransformToRegdoll(origin.GetChild(i), regdoll.GetChild(i));
            }

            regdoll.GetChild(i).localPosition = origin.GetChild(i).localPosition;
            regdoll.GetChild(i).localRotation = origin.GetChild(i).localRotation;
        }
    }

    public void Damage(float TheDamage)
    {
        currentHealth -= TheDamage;

        Debug.Log("�¾Ҵ� ����");

        if (currentHealth <= 0)
        {
            ChangeCharacter();
        }
    }

}
