using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
   private Slider slider;

   public float FillSpeed = 0.01f;
   private float targetProgress = 1;
   // Start is called before the first frame update
   private GameObject loader;

   public Text timeUp;

   void Start()
   {
      slider = gameObject.GetComponent<Slider>();
      //IncrementProgress(0.75f);
      loader = GameObject.FindGameObjectWithTag("loader");
   }

   // Update is called once per frame
   void Update()
   {
      if (loader.GetComponent<GameLoader>().loaded)
      {
         if (slider.value < targetProgress)
         {
            slider.value += FillSpeed * 0.1f * Time.deltaTime;
         }

      }
      if (slider.value == targetProgress)
      {
         timeUp.gameObject.SetActive(true);
         StartCoroutine(changeScene());
      }


   }

   IEnumerator changeScene()
   {
      yield return new WaitForSeconds(3);
      SceneManager.LoadScene(0);
   }
   public void IncrementProgress(float newProgress)
   {
      targetProgress = slider.value + newProgress;
   }
}
