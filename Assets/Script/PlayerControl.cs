using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator myAnim;

    [SerializeField]
    private float speed = 0F;

    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;
    public float typingSpeed = 1.0f;


    AudioSource myAudio;
    public AudioClip WalkSound;
    public AudioClip AttackSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;

        myAnim.SetFloat("moveX", rb.velocity.x);
        myAnim.SetFloat("moveY", rb.velocity.y);
        

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }


      

    }

    void Update()
    {
        if (isAttacking)
        {

            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                myAnim.SetBool("isAttacking", false);

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            attackCounter = attackTime;
            myAnim.SetBool("isAttacking", true);
            myAudio.PlayOneShot(AttackSound);
            isAttacking = true;
        }
    }
}
