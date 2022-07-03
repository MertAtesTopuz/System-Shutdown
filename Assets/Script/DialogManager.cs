using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public Dialog dialog;

    Queue<string> sentences;

    public GameObject dialogPanel;
    public TextMeshProUGUI displayText;

    string activeSentence;
    public float typingSpeed;

    private bool calis = false;

    Animator animator;

    AudioSource myAudio;
    public AudioClip speakSound;

    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (calis)
        {
            
            
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (displayText.text == activeSentence)
                    {
                        DisplayNextSentence();
                        Debug.Log("cal?s?yor");
                    }

                }
            
        }
    }

    void StartDiologue()
    {
        sentences.Clear();

        foreach (string sentence in dialog.sentenceList)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            return;
        }

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;
        myAudio.PlayOneShot(speakSound);

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));

    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {

            displayText.text += letter;
            animator.SetBool("isTalking", true);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            dialogPanel.SetActive(true);
            StartDiologue();
            calis = true;
        }
        
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            dialogPanel.SetActive(false);
            animator.SetBool("isTalking", false);
            StopAllCoroutines();
            calis = false;
        }
    }
}
