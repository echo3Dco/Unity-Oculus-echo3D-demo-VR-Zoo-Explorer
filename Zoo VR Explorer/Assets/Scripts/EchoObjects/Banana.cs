using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEditor.Events;
using UnityEngine.UI;

public class Banana : MonoBehaviour
{
   XRGrabInteractable grabInteractable;
   MeshCollider col;
   Rigidbody rb;
   Transform centerTrans;

   public float respawnTime = 1.0f;
   public static int TotalBanana = 0;

   private GameObject fruitParent;

   void Start()
   {
      this.tag = "banana";
      grabInteractable = this.gameObject.GetComponent<XRGrabInteractable>();
      col = GetComponent<MeshCollider>();
      col.convex = true;
      rb = GetComponent<Rigidbody>();
      rb.mass = 0.22f;

      centerTrans = new GameObject("center").transform;
      centerTrans.SetParent(this.transform);

      grabInteractable.selectEntered.AddListener(selectEntered => selectEn());
      grabInteractable.selectExited.AddListener(selectExited => selectEx());

      grabInteractable.hoverEntered.AddListener(hoverEntered => HoverOver());
      grabInteractable.hoverExited.AddListener(hoverExited => HoverEnd());


      StartCoroutine(activate());
      StartCoroutine(bananaWave());


      fruitParent = GameObject.Find("Fruits");
   }

   private void Update()
   {

      centerTrans.localPosition = rb.centerOfMass;
      //grabInteractable.attachTransform = centerTrans;
   }

   IEnumerator activate()
   {
      rb.useGravity = false;
      float waitNum = Random.Range(0f, 5f);
      yield return new WaitForSeconds(waitNum);
      rb.useGravity = true;
   }

   IEnumerator bananaWave()
   {
      while (true)
      {
         yield return new WaitForSeconds(respawnTime);
         spawnBanana();
      }
   }

   private void spawnBanana()
   {
      if (TotalBanana < 10)
      {
         TotalBanana++;

         GameObject ban = Instantiate(gameObject) as GameObject;
         ban.name = "banana(" + TotalBanana.ToString() + ")";
         ban.transform.position = new Vector3(Random.Range(-10f, 10f), 4f, Random.Range(-10f, 10f));

         ban.transform.SetParent(fruitParent.transform);
      }
   }

   private void selectEn()
   {
      col.isTrigger = true;
      rb.isKinematic = true;
      Debug.Log(col.name + " selected");
   }

   private void selectEx()
   {
      col.isTrigger = false;
      rb.isKinematic = false;
      Debug.Log(col.name + " unselected");
   }


   private void HoverOver()
   {
      //   this.transform.localRotation = Quaternion.Euler(0, 60, 0);
      //   Debug.Log("score value" + theScore.scoreValue);
      //   theScore.scoreValue += 1;

   }
   private void HoverEnd()
   {
      //   this.transform.localRotation = Quaternion.Euler(60, 0, 60);
   }
}
