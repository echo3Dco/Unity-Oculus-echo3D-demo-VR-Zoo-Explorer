using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
     {
         transform.LookAt(mainCamera.transform);
         transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
     }
}
