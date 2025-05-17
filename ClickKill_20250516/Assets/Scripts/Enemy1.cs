using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IDamageable
{
    public GameObject currentCharacter;
    public GameObject regdollCharacter;

    public Rigidbody spine;

    public float maxHealth;
    public float currentHealth;

    public bool bDead;

    private void Start()
    {
        currentHealth = maxHealth;
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

        Debug.Log("¸Â¾Ò´Ù À¸¾Ç");

        if (currentHealth <= 0)
        {
            ChangeCharacter();
        }
    }

}
