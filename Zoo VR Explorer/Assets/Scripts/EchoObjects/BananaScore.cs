using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BananaScore : MonoBehaviour
{

   public int scoreValue = 0;
   Text score;
   // Start is called before the first frame update
   void Start()
   {
      score = GetComponent<Text>();
   }

   // Update is called once per frame
   void Update()
   {
      score.text = "Score: " + scoreValue;
      if (scoreValue == 10)
      {
         score.text = "The monkey is full! \n Good job.";
         StartCoroutine(changeScene());
      }

   }

   IEnumerator changeScene()
   {
      yield return new WaitForSeconds(5);
      SceneManager.LoadScene(0);
   }
}
