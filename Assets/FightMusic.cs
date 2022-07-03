using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMusic : MonoBehaviour
{
    AudioSource audio;
    public AudioClip fightMusic;
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audio.PlayOneShot(fightMusic);
    }
}
