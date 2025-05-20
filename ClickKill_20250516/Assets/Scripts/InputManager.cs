using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private RaycastHit hit;

    public float attackPoint;

    public List<GameObject> assistantList = new List<GameObject>();

    public List<Transform> areaList = new List<Transform>();

    private void Update()
    {
        InputInform();
       // TouchInput();
    }

    private void InputInform()
    {
      if(Input.GetMouseButtonDown(0))
      {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                //if(hit.collider.gameObject.tag == "Enemy")
                //{
                //    hit.collider.gameObject.SetActive(false);
                //}
            
                if(hit.collider.gameObject.tag == "Enemy")
                {
                    IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();

                    if(damageable != null)
                    {
                        AudioManager.Instance.PlaySFX("ShotSound");
                        damageable.Damage(attackPoint);
                    }

                    Debug.Log("�� ����");
                }

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
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();

                        if (damageable != null)
                        {
                            AudioManager.Instance.PlaySFX("ShotSound");
                            damageable.Damage(attackPoint);
                        }

                    }

                    Debug.Log("hit name  : " + hit.collider.gameObject.name);
                }
            }
        }
    }

    public void SpawnAssistant()
    {
        int randSpawn = Random.Range(0, assistantList.Count);
        int randArea = Random.Range(0, areaList.Count);

        GameObject assistant = Instantiate(assistantList[randSpawn], areaList[randArea].position, Quaternion.identity);
    }

}
