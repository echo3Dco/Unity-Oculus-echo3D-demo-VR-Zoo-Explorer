using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Monkey : MonoBehaviour
{
   // Start is called before the first frame update

   MeshCollider col;

   private string audioName = "echoAR (video)/holder/5 Audio_Monkey.mp4";
   VideoPlayer audioSource;
   private bool found;

   public Vector3 Pos = new Vector3(0, -0.4f, 1f);

   //scorekeeping
   BananaScore theScore;

   void Start()
   {
      col = GetComponent<MeshCollider>();
      col.isTrigger = true;

      this.transform.position = Pos;
      found = false;

      //score
      GameObject BananaObject = GameObject.Find("Canvas/BananaScore");

      if (SceneManager.GetActiveScene().name.Equals("Monkey"))
      {
         Debug.Log("is monkey scene");
         theScore = BananaObject.GetComponent<BananaScore>();
      }
   }

   private void Update() {
      //this.transform.position = Pos;
      if (!found && GameObject.Find(audioName) != null){
         found = true;
         audioSource = GameObject.Find(audioName).GetComponent<VideoPlayer>();
      }   
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("banana"))
      {
         Debug.Log("collide with" + other.gameObject.name);

         audioSource.Play();
         theScore.scoreValue += 1;

         Destroy(other.gameObject);
      }
   }
}
