using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerDestinationBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            SendMessageUpwards("GetPoint");
        }
    }
}
