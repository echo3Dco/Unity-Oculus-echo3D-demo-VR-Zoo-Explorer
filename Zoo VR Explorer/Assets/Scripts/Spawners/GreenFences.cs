using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFences : MonoBehaviour
{
    public GameObject fence;
    private void OnEnable() {
        for(int i = 0; i < transform.childCount; i++){
            GameObject newTree = Instantiate(fence);
            newTree.transform.parent = transform.GetChild(i);
            newTree.transform.localPosition = new Vector3(0f, 0f, 0f);
            newTree.transform.localRotation = Quaternion.identity;
            newTree.transform.localScale = new Vector3(1f, 1f, 1f);

            MeshRenderer meshRenderer = newTree.GetComponentInChildren<MeshRenderer>();
            Material treeMat = Resources.Load("Materials/GreenWood", typeof(Material)) as Material;
            meshRenderer.material = treeMat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
