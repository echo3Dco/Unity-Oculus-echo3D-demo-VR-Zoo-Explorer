using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public TextManager textManager;
    public GameObject image;

    void Start()
    {
        textManager = GetComponent<TextManager>();
    }

    private void OnTriggerEnter(Collider other) {
        textManager.enabled = true;
    }

    private void OnTriggerExit(Collider other) {
        textManager.enabled = false;
        image.SetActive(false);
        StopCoroutine(textManager.currentScrollType);
    }
}
