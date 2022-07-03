using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class İceZombiControl : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePos;
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float MaxRange = 0f;
    [SerializeField]
    private float MinRange = 0f;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerControl>().transform;
    }

    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= MaxRange && Vector3.Distance(target.position, transform.position) >= MinRange)
        {
            followPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= MaxRange)
        {
            GoHome();
        }

    }

    public void followPlayer()
    {
        myAnim.SetBool("isRunning", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

    }

    public void GoHome()
    {
        myAnim.SetFloat("moveX", (homePos.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            myAnim.SetBool("isRunning", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MyWeapon")
        {
            Vector2 diffrence = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + diffrence.x, transform.position.y + diffrence.y);
        }
    }
}
