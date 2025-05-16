using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private RaycastHit hit;

    private void Update()
    {
       // InputInform();
        TouchInput();
    }

    private void InputInform()
    {
      if(Input.GetMouseButtonDown(0))
      {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("hit name  : " + hit.collider.gameObject.name);
            }
      }
    }

    private void TouchInput()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if(Physics.Raycast(ray, out hit))
                {
                    Debug.Log("hit name  : " + hit.collider.gameObject.name);
                }
            }
        }
    }

}
