using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Log : MonoBehaviour
{
   // Start is called before the first frame update
   [SerializeField] public GameObject[] logs;

   private static int TotalLogs = 0;
   //private bool activated = false;

   private bool[] activated = { false, false, false, false, false, false };

   private bool done = false;

   GameObject sloth;

   public GameObject timer;

   public GameObject congrats;
   void Start()
   {
      //if for every single log (labelled log - gotta create the tag, within certain radius there is something labelled/tagged log as well, then it is close enough and then the sloth will find a good way home.)
   }

   // Update is called once per frame
   void Update()
   {
      if (TotalLogs == 6 && !done)
      {
         done = true;
         timer.SetActive(false);
         moveSloth();
      }


   }

   //private Color m_oldColor = Color.white;

   void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         Renderer render = GetComponent<Renderer>();
         //m_oldColor = render.material.color;
         render.material.color = Color.green;
         string name = gameObject.name;
         switch (name)
         {
            case "1":
               //if not currently active, then add more to totalLogs
               if (!activated[0])
               {
                  activated[0] = true;
                  TotalLogs++;
                  StartCoroutine(moveLog(0));
               }
               //    if (!logs[0].active)
               //    {
               //       logs[0].SetActive(true);
               //       TotalLogs++;
               //    }
               break;
            case "2":
               if (!activated[1])
               {
                  activated[1] = true;
                  TotalLogs++;
                  StartCoroutine(moveLog(1));
               }
               //    if (!logs[1].active)
               //    {
               //       logs[1].SetActive(true);
               //       TotalLogs++;

               //    }
               break;
            case "3":
               if (!activated[2])
               {
                  activated[2] = true;
                  TotalLogs++;
                  StartCoroutine(moveLog(2));
               }
               //    if (!logs[2].active)
               //    {
               //       logs[2].SetActive(true);
               //       TotalLogs++;

               //    }
               break;
            case "4":
               if (!activated[3])
               {
                  activated[3] = true;
                  TotalLogs++;
                  StartCoroutine(moveLog(3));
               }
               //    if (!logs[3].active)
               //    {
               //       logs[3].SetActive(true);
               //       TotalLogs++;
               //    }
               break;
            case "5":
               if (!activated[4])
               {
                  activated[4] = true;
                  TotalLogs++;
                  StartCoroutine(moveLog(4));
               }
               //    if (!logs[4].active)
               //    {
               //       logs[4].SetActive(true);
               //       TotalLogs++;
               //    }
               break;
            case "6":
               if (!activated[5])
               {
                  activated[5] = true;
                  TotalLogs++;
                  StartCoroutine(moveLog(5));
               }
               //    if (!logs[5].active)
               //    {
               //       logs[5].SetActive(true);
               //       TotalLogs++;
               //    }
               break;
            default:
               break;
         }

      }
   }

   void OnTriggerExit(Collider other)
   {
      //   if (other.tag == "Player")
      //   {
      //      Renderer render = GetComponent<Renderer>();
      //      //m_oldColor = render.material.color;
      //      render.material.color = new Color(82, 27, 25);
      //   }
   }

   void moveSloth()
   {
      sloth = GameObject.Find("echoAR/Ground sloth.glb");
      Debug.Log("Move Sloth");
      sloth.transform.Rotate(0f, -90f, 0f, Space.Self);
      StartCoroutine(toDestination());
      congrats.SetActive(true);
      StartCoroutine(changeScene());
   }


   IEnumerator changeScene()
   {
      yield return new WaitForSeconds(10);
      SceneManager.LoadScene(0);
   }

   IEnumerator toDestination()
   {
      sloth = GameObject.Find("echoAR/Ground sloth.glb");
      Destroy(sloth.transform.GetChild(0).GetChild(0).GetComponent<Rigidbody>());
      Vector3 targetPosition = new Vector3(14f, 0f, 0f);
      while (sloth.transform.position != targetPosition)
      {
         yield return 0;
         // Move one step toward the target at our given speed.
         sloth.transform.position = Vector3.MoveTowards(
               sloth.transform.position,
               targetPosition,
               0.3f * Time.deltaTime
          );
      }
   }

   IEnumerator moveLog(int index)
   {

      Vector3 targetPosition = logs[index].transform.position;

      while (transform.position != targetPosition)
      {
         /*
         yield return new WaitForSeconds(0.1f);
         // Move one step toward the target at our given speed.
         transform.position = Vector3.MoveTowards(
               transform.position,
               targetPosition,
               30f * Time.deltaTime
          );*/
          yield return 0;
          transform.position = Vector3.Lerp(transform.position, targetPosition, 0.3f);
      }
      Renderer render = GetComponent<Renderer>();
      render.material.color = Color.gray;
   }

}
