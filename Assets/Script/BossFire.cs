using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{

    private Transform target;
    public Transform FirePos;
    public GameObject FireBallPrefab;
    [SerializeField]
    private float Range = 0f;
    [SerializeField]
    private float FireTime = 0f;
    private float currentFireTime;
    AudioSource sesdosyasi;
    public AudioClip ates;


    void Start()
    {
        target = FindObjectOfType<PlayerControl>().transform;
        sesdosyasi = gameObject.GetComponent<AudioSource>();
        currentFireTime = FireTime;

    }

    void Update()
    {
        if (currentFireTime <=0)
        {
            Shoot();
            currentFireTime = FireTime;
        }
        else
        {
            currentFireTime -= Time.deltaTime;
           
        }
        
    }

    void Shoot()
    {
        if (Vector3.Distance(target.position, transform.position) <= Range)
        {
            MakeFireBall();
        }
    }

    void MakeFireBall()
    {
        sesdosyasi.PlayOneShot(ates);
        Instantiate(FireBallPrefab, FirePos.position, FirePos.rotation);
    }

   
}
