using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TextTrigger2 : MonoBehaviour
{
    public AnimalTextManager textManager;
    public GameObject image;
    Player player;

    private VideoPlayer voice;
    private string audioName = "echoAR (video)/holder/6 Animal Crossing Isabelle Voice Clips.mp4";
    private bool audioFound;


    void Start()
    {
        textManager = GetComponent<AnimalTextManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        audioFound = false;
    }

    private void Update()
    {
        if (!audioFound && GameObject.Find(audioName) != null)
        {
            audioFound = true;
            voice = GameObject.Find(audioName).GetComponent<VideoPlayer>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            voice.Play();
            int level = textManager.animalNumber;
            if (player.firstVisit[level] == 0)
            {
                textManager.enabled = true;
            }
            else
            {
                textManager.enabled = false;
                player.SavePlayer();
                SceneManager.LoadScene(level);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            voice.Pause();
            textManager.enabled = false;
            image.SetActive(false);
            StopCoroutine(textManager.currentScrollType);
        }
    }
}
