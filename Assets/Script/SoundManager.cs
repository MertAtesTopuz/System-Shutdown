using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource sesdosyasi;
    public AudioClip yurume;
    HealthManager heal;
    public bool sespnl = false;

    void Start()
    {
        sesdosyasi = gameObject.GetComponent<AudioSource>();

    }


    void Update()

    {

        if (sespnl == false)
        {


            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
            {

                sesdosyasi.Play();
            }
            
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            {
                sesdosyasi.Stop();

            }
            if (Time.timeScale == 0.0f)
            {
                sesdosyasi.Stop();
            }
        }
    }
}
