using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Macaw : MonoBehaviour
{
    MeshCollider col;
    public VideoPlayer voice;
    private string audioName = "echoAR (video)/holder/7 Audio_Macaw.mp4";
    private bool audioFound;

    GameObject player;
    private bool played;
    private float audioDis = 3f;

    void Start()
    {
        played = false;
        col = GetComponent<MeshCollider>();
        col.isTrigger = true;

        audioFound = false;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!audioFound && GameObject.Find(audioName) != null)
        {
            audioFound = true;
            voice = GameObject.Find(audioName).GetComponent<VideoPlayer>();
        }

        Vector3 disVec = player.transform.position - this.transform.position;
        disVec.y = 0;
        float distance = disVec.magnitude;
        if (audioFound)
        {
            if (distance <= audioDis)
            {
                voice.Play();
            }/* else
            {
                voice.Pause();
            }*/
        }
    }
}
