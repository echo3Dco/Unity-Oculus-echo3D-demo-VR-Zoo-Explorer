using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int level;
    public static bool firstLoad = true;
    public int[] firstVisit;
    public Transform ReturnPositions;

    void Awake()
    {
        firstVisit = new int[6];
        Debug.Log(firstVisit);
        if (!firstLoad)
        {
            LoadPlayer();
        }
    }

    public void SavePlayer()
    {
        firstLoad = false;
        SaveSystem.SavePlayer(this);
        Debug.Log("data saved");
    }

    public void LoadPlayer()
    {
        Debug.Log("data loaded");
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        this.transform.position = ReturnPositions.GetChild(level).position;
        this.transform.rotation = ReturnPositions.GetChild(level).rotation;

        firstVisit = data.firstVisit;

    }


}
