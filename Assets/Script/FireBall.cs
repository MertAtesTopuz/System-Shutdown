using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Transform target;
    private Transform target2;
    private EnemyHealth EHealth;
    [SerializeField]
    private float speed = 2f;
    private HealthManager healthMan;
    [SerializeField]
    private int damageToGive = 10;

    void Start()
    {
        target = GameObject.Find("Character").transform;
        target2 = GameObject.Find("HurtPos").transform;
        EHealth = FindObjectOfType<EnemyHealth>();
        healthMan = FindObjectOfType<HealthManager>();

    }

    void Update()
    {
        followPlayer();

    }

    public void followPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

    }

    public void followBoss()
    {
        transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed * Time.deltaTime);
    }
    public void DstroyFire(GameObject other)
    {
        Destroy(other.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
            Destroy(gameObject);
        }
        if(other.tag == "HurtPos")
        {
            EHealth.HurtEnemy(damageToGive);
            Destroy(gameObject);
        }
    }

    public void tagetChange()
    {
        target = target2;
    }
}
