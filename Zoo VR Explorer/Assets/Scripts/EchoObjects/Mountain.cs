using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEditor.Events;
using UnityEngine.UI;

public class Mountain : XRBaseInteractable
{
   XRGrabInteractable grabInteractable;
   MeshCollider col;
   Rigidbody rb;

   // protected override void OnSelectEnter(XRBaseInteractor interactor)
   // {
   //    base.OnSelectEnter(interactor);
   //    Debug.Log("Select enter");
   // }

   // protected override void OnSelectExit(XRBaseInteractor interactor)
   // {
   //    base.OnSelectExit(interactor);
   //    Debug.Log("Select exit");
   // }

   void Start()
   {
      this.tag = "";
      grabInteractable = this.gameObject.GetComponent<XRGrabInteractable>();
      col = GetComponent<MeshCollider>();
      col.convex = true;
      rb = GetComponent<Rigidbody>();
      rb.mass = 0.22f;

      //grabInteractable.selectEntered.AddListener(selectEntered => selectEn());
      grabInteractable.selectExited.AddListener(selectExited => selectEx());

      grabInteractable.hoverEntered.AddListener(hoverEntered => HoverOver());
      grabInteractable.hoverExited.AddListener(hoverExited => HoverEnd());
      transform.position = new Vector3(0f, 20f, 10f);
      StartCoroutine(noGrab());
      //rb.isKinematic = true;
   }

   IEnumerator noGrab()
   {
      yield return new WaitForSeconds(5);
      rb.isKinematic = true;

   }
   private void selectEn()
   {
      col.isTrigger = true;
      //rb.isKinematic = true;
      Debug.Log(col.name + " selected");
   }

   private void selectEx()
   {
      col.isTrigger = false;
      //rb.isKinematic = false;
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
