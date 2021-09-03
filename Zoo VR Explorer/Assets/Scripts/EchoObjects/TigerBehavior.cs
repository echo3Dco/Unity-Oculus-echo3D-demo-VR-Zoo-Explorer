using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TigerBehavior : MonoBehaviour
{
    public static bool startRoaming = false;
    public NavMeshAgent agent;
    public float visionLength;
    public Transform player;
    public Vector3 randomSpot;
    public bool detected;
    public bool roam;
    private VideoPlayer voice;
    private string audioName = "echoAR (video)/holder/8 Tiger growling.mp4";
    private bool audioFound;

    
    public int upperX, lowerX, upperZ, lowerZ;

    private void OnEnable() {
        agent = GetComponent<NavMeshAgent>();
        roam = true;
        detected = false;
        audioFound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioFound && GameObject.Find(audioName) != null)
        {
            audioFound = true;
            voice = GameObject.Find(audioName).GetComponent<VideoPlayer>();
            voice.Play();
        }
        if(startRoaming){
            if(detected){
                //voice.playbackSpeed = 2.0f;
                voice.Play();
                agent.speed = 3;
            }
            else{
                //voice.playbackSpeed = 1.0f;
                voice.Pause();
                agent.speed = 1.5f;
            }

            RaycastHit hit;
            Vector3 rayDirection = player.transform.position - transform.position;

            if ((Vector3.Angle(rayDirection, transform.forward)) <= 120 * 0.5f)
            {
                // Detect if player is within the field of view
                if (Physics.Raycast(transform.position, rayDirection, out hit, visionLength))
                {
                    DetectPlayer();
                }
                else if(detected)
                {
                    UndetectPlayer();
                }
            }

            if(roam || Vector3.Distance(transform.position, randomSpot) <= 1f){
                SetRandomDestination();
            }
            else if(detected){
                agent.destination = player.position;
            }
        }
        else{
            /*if(transform.GetChild(0).GetChild(0)){
                startRoaming = true;
            }*/
        }
        
    }

    public void DetectPlayer()
    {
        RaycastHit hit;

        if (Physics.Linecast(transform.position, player.transform.position, out hit))
        {
            //Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                detected = true;
            }
            /*else
            {
                detected = false;
            }*/
        }
    }

    public void UndetectPlayer()
    {
        detected = false;
        roam = true;
    }

    public void SetRandomDestination(){
        randomSpot = new Vector3(Random.Range(lowerX, upperX), 1.5f, Random.Range(lowerZ,upperZ));
        agent.destination = randomSpot;
        roam = false;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(0);
        }
    }
}
