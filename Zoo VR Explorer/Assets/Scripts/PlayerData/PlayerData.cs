using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int[] firstVisit;


    public PlayerData(Player player){
        level = player.level;
        
        firstVisit = new int[6];
        for(int i = 0; i < 6; i++){
            firstVisit[i] = player.firstVisit[i];
        }
    }
}
