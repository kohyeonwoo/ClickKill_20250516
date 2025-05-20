using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollisionType { NONE, Sharp, Club}

public class PlayerAttackCollision : MonoBehaviour
{

    public float attackPoint;

    public CollisionType collisionType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if(damageable != null)
            {
                damageable.Damage(attackPoint);

                if(collisionType == CollisionType.Sharp)
                {
                    AudioManager.Instance.PlaySFX("SharpHitSound");
                }

                if (collisionType == CollisionType.Club)
                {
                    AudioManager.Instance.PlaySFX("ClubHitSound");
                }

            }
        } 
    }

}
