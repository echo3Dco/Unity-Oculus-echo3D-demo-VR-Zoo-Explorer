using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLoader2 : MonoBehaviour
{
    public Animator levelLoader;
    public GameObject echoARPrefab;
    public int echoARModels;
    public bool loaded, turnedOff;
    public EllipsesTextAnimation text;
    public GameObject leftHand, rightHand, locomotionSystem, xrDeviceSimulator;
    public Coroutine turnOff;

    // Update is called once per frame
    void Update()
    {
        if(!loaded && echoARModels == echoARPrefab.transform.childCount){
            for(int i = 0; i < echoARPrefab.transform.childCount; i++){
                if(!echoARPrefab.transform.GetChild(i).GetChild(0)){
                    break;
                }
                if(i + 1 == echoARPrefab.transform.childCount){
                    leftHand.SetActive(true);
                    rightHand.SetActive(true);
                    locomotionSystem.SetActive(true);
                    xrDeviceSimulator.SetActive(true);
                    text.loaded = true;
                    levelLoader.SetTrigger("Loaded");
                    loaded = true;
                    turnedOff = true;
                }
            }
        }
        if(turnedOff){
            turnOff = StartCoroutine(turningOff());
            turnedOff = false;
        }
    }

    public IEnumerator turningOff(){
        yield return new WaitForSeconds(10f);
        this.gameObject.SetActive(false);
    }
}