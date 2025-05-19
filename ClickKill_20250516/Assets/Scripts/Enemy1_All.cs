using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_All : MonoBehaviour
{
    public GameObject characterObject;
    public GameObject regdollObject;

    public void OnEnable()
    {
        characterObject.SetActive(true);
        regdollObject.SetActive(false);
    }
}
