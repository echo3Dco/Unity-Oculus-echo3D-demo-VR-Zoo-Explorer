using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLoader : MonoBehaviour
{
    public Animator levelLoader;
    public GameObject echoARPrefab;
    public bool loaded, turnedOff;
    public EllipsesTextAnimation text;
    private GameObject player;
    public GameObject leftHand, rightHand, locomotionSystem, xrDeviceSimulator;
    public Coroutine turnOff;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = player.transform.position;
        this.transform.rotation = player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!loaded)
        {
            for (int i = 0; i < echoARPrefab.transform.childCount; i++)
            {
                if (echoARPrefab.transform.childCount == 0)
                    return;
                if (echoARPrefab.transform.GetChild(i).gameObject.activeSelf && echoARPrefab.transform.GetChild(i).childCount == 0)
                {
                    break;
                }
                if (i + 1 == echoARPrefab.transform.childCount)
                {
                    leftHand.SetActive(true);
                    rightHand.SetActive(true);
                    locomotionSystem.SetActive(true);
                    //xrDeviceSimulator.SetActive(true);
                    text.loaded = true;
                    levelLoader.SetTrigger("Loaded");
                    loaded = true;
                    turnedOff = true;
                }
            }
        }
        if (turnedOff)
        {
            turnOff = StartCoroutine(turningOff());
            turnedOff = false;
        }
    }

    public IEnumerator turningOff()
    {
        yield return new WaitForSeconds(10f);
        this.gameObject.SetActive(false);
        TigerBehavior.startRoaming = true;
    }
}
