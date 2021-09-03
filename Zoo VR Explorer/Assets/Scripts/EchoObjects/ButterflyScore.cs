using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButterflyScore : MonoBehaviour
{

   public TMP_Text text;
   public int scoreValue = 0;
   // Start is called before the first frame update
   void Start()
   {
      
   }

   // Update is called once per frame
   void Update()
   {
      text.text = "SCORE: " + scoreValue;
      if (scoreValue == 5)
      {
         text.text = "YOU CAUGHT 5 BUTTERFLIES\nGOOD JOB!";
         StartCoroutine(changeScene());
      }

   }

   IEnumerator changeScene()
   {
      yield return new WaitForSeconds(5);
      SceneManager.LoadScene(0);
   }
}
