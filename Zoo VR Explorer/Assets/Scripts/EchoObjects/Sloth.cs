using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEditor.Events;
using UnityEngine.UI;

public class Sloth : MonoBehaviour
{
   XRGrabInteractable grabInteractable;
   MeshCollider col;
   Rigidbody rb;

   void Start()
   {
      this.tag = "sloth";
      grabInteractable = this.gameObject.GetComponent<XRGrabInteractable>();
      col = GetComponent<MeshCollider>();
      col.convex = true;
      rb = GetComponent<Rigidbody>();
      rb.mass = 0.22f;
      transform.position = new Vector3(0f, 0.5f, 0f);
      rb.velocity = Vector3.zero;
      

      // grabInteractable.selectEntered.AddListener(selectEntered => selectEn());
      // grabInteractable.selectExited.AddListener(selectExited => selectEx());

      // grabInteractable.hoverEntered.AddListener(hoverEntered => HoverOver());
      // grabInteractable.hoverExited.AddListener(hoverExited => HoverEnd());

   }

   private void Update()
   {
      // if (transform.position != new Vector3(0f, 0f, 16.5f))
      // {
      //    transform.position = new Vector3(0f, 0f, 16.5f);
      // }



      //grabInteractable.attachTransform = centerTrans;
   }

   private void FixedUpdate()
   {
      //rb.velocity = Vector3.zero;

   }
   // private void selectEn()
   // {
   //    col.isTrigger = true;
   //    rb.isKinematic = true;
   //    Debug.Log(col.name + " selected");
   // }

   // private void selectEx()
   // {
   //    col.isTrigger = false;
   //    rb.isKinematic = false;
   //    Debug.Log(col.name + " unselected");
   // }


   // private void HoverOver()
   // {
   //    //   this.transform.localRotation = Quaternion.Euler(0, 60, 0);
   //    //   Debug.Log("score value" + theScore.scoreValue);
   //    //   theScore.scoreValue += 1;

   // }
   // private void HoverEnd()
   // {
   //    //   this.transform.localRotation = Quaternion.Euler(60, 0, 60);
   // }
}
