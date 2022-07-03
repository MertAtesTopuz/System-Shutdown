using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SystemError : MonoBehaviour
{
    public GameObject ErrorPnl;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ErrorPnl.SetActive(true);
            Time.timeScale = 0.0f;

        }
    }

    public void Close()
    {
        ErrorPnl.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;

    }
}
