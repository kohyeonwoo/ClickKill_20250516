using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_DeadBody : MonoBehaviour
{
    public GameObject alls;

    private void OnEnable()
    {
        Invoke("Dissapear", 2.0f);
    }

    private void Dissapear()
    {
        alls.SetActive(false);
    }

}
