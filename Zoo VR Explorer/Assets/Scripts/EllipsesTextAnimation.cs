using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EllipsesTextAnimation : MonoBehaviour
{
    public TMP_Text text;
    public int count;
    public float timer;
    public bool loaded;

    // Update is called once per frame
    void Update()
    {
        if(!loaded){
            timer += Time.deltaTime;

            if(timer >= 0.5f){
                if(count < 3){
                    count++;
                }
                else{
                    count = 0;
                }
                timer = 0f;
            }

            text.text = "Now Loading";
            for(int i = 0; i < count; i++){
                text.text += ".";
            }
        }
        else{
            text.text = "Enjoy!";
        }
    }
}
