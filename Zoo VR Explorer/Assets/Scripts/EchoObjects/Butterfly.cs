using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Butterfly : MonoBehaviour
{

   private float respawnTime = 0.1f;
   private static int TotalButterflies = 0;
   private float nextTime = 0;

   private GameObject center;
   private Vector3 axis = Vector3.up;
   private float radius;
   private float rotationSpeed;
   private Rigidbody rb;

   ButterflyScore theScore;


   XRGrabInteractable grabInteractable;
   MeshCollider col;

   void Start()
   {
      //initialize variables
      rb = gameObject.GetComponent<Rigidbody>();
      rb.isKinematic = true;
      rb.useGravity = false;
      radius = Random.Range(1f, 5f);
      rotationSpeed = Random.Range(10f, 50f);

      GameObject ButterflyObject = GameObject.Find("Canvas/ButterflyScore");
      theScore = ButterflyObject.GetComponent<ButterflyScore>();

      this.tag = "butterfly";
      grabInteractable = this.gameObject.GetComponent<XRGrabInteractable>();
      col = GetComponent<MeshCollider>();
      rb = GetComponent<Rigidbody>();

      center = new GameObject("center");
      center.transform.position = new Vector3(Random.Range(-20f, 20f), Random.Range(0f, 1f), Random.Range(-20f, 20f));

      transform.position = (transform.position - center.transform.position).normalized * radius + center.transform.position;

      transform.localScale = new Vector3(0.5f,0.5f,0.5f);


      grabInteractable.selectEntered.AddListener(selectEntered => selectEn());
      grabInteractable.selectExited.AddListener(selectExited => selectEx());
      grabInteractable.hoverEntered.AddListener(hoverEntered => HoverOver());
      grabInteractable.hoverExited.AddListener(hoverExited => HoverEnd());


      StartCoroutine(butterflyWave());
      StartCoroutine(butterflyMove());
   }

   IEnumerator butterflyWave()
   {
      while (true)
      {
         yield return new WaitForSeconds(respawnTime);
         spawnButterfly();
      }
   }

   IEnumerator butterflyMove()
   {
      while (true)
      {
         yield return new WaitForSeconds(Random.Range(6f, 20f));
         moveButterfly();
      }
   }

   private void spawnButterfly()
   {
      if (TotalButterflies < 10)
      {
         TotalButterflies++;
         Debug.Log(TotalButterflies);

         GameObject fly = Instantiate(gameObject) as GameObject;
         fly.name = "butterfly(" + TotalButterflies.ToString() + ")";
      }
   }

   private void moveButterfly()
   {
      center.transform.position = new Vector3(Random.Range(-20f, 20f), Random.Range(0f, 2f), Random.Range(-20f, 20f));

      transform.position = (transform.position - center.transform.position).normalized * radius + center.transform.position;

   }
   void Update()
   {

      //circling
      //lookat
      var dir = -(center.transform.position - transform.position);
      var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
      //here you need to use the same axis you use in the rotate around method. If you use .forward use it here as well.
      transform.rotation = Quaternion.AngleAxis(angle, axis);

      var rotation = transform.rotation;
      transform.RotateAround(center.transform.position, axis, rotationSpeed * Time.deltaTime);
      transform.rotation = rotation;

   }

   private void selectEn()
   {
      col.isTrigger = true;
      //   rb.isKinematic = true;
      //   Debug.Log(col.name + " selected");
   }

   private void selectEx()
   {
      col.isTrigger = false;
      //   rb.isKinematic = false;
      //   Debug.Log(col.name + " unselected");
   }


   private void HoverOver()
   {
      theScore.scoreValue += 1;
      Destroy(gameObject);

   }
   private void HoverEnd()
   {
      //   this.transform.localRotation = Quaternion.Euler(60, 0, 60);
   }



}
