using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    private bool flashActive;
    [SerializeField]
    private float flashLenght = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;
    public PnlControl control;
    private float waitToDead = 2f;
    public AudioClip olme;
    public AudioClip hasar;
    AudioSource sesdosyasi;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        sesdosyasi = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLenght * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLenght;
        sesdosyasi.PlayOneShot(hasar);
        if (currentHealth == 0)
        {
            gameObject.SetActive(false);
            control.kaybettin();
            Time.timeScale = 0.0f;
            
        }
    }
}
