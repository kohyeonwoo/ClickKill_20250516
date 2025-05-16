using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameObject currentCharacter;
    public GameObject regdollCharacter;

    public Rigidbody spine;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeCharacter();
        }
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

}
