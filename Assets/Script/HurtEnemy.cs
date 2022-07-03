using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 2;



    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy"  )
        {
            EnemyHealth EHealth;
            EHealth = other.gameObject.GetComponent<EnemyHealth>();
            EHealth.HurtEnemy(damageToGive);
        }

        if (other.tag == "FireBall")
        {
            other.GetComponent<FireBall>().tagetChange();
        }
    }
}
