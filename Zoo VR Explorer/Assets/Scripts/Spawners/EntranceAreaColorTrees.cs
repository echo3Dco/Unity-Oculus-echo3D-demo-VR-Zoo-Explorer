using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceAreaColorTrees : MonoBehaviour
{
    public GameObject tree;
    private void OnEnable() {
        for(int i = 0; i < transform.childCount; i++){
            GameObject newTree = Instantiate(tree);
            newTree.transform.parent = transform.GetChild(i);
            newTree.transform.localPosition = new Vector3(0f, 0f, 0f);
            newTree.transform.localRotation = Quaternion.identity;
            newTree.transform.localScale = new Vector3(1f, 1f, 1f);

            MeshRenderer meshRenderer = newTree.GetComponent<MeshRenderer>();

            Material treeMat1 = Resources.Load("Materials/ColorTrees/Green/Leaves3", typeof(Material)) as Material;
            Material treeMat2 = Resources.Load("Materials/ColorTrees/Green/Leaves 1", typeof(Material)) as Material;
            Material treeMat3 = Resources.Load("Materials/ColorTrees/Green/Tree 1", typeof(Material)) as Material;

            if((i >= 0 && i <= 3) || (i >= 15 && i <= 16)){
                treeMat1 = Resources.Load("Materials/ColorTrees/Red/Leaves", typeof(Material)) as Material;
                treeMat2 = Resources.Load("Materials/ColorTrees/Red/Leaves2", typeof(Material)) as Material;
                treeMat3 = Resources.Load("Materials/ColorTrees/Red/Tree", typeof(Material)) as Material;
            }
            else if(i >= 7 && i <= 9){
                treeMat1 = Resources.Load("Materials/ColorTrees/Blue/Leaves3", typeof(Material)) as Material;
                treeMat2 = Resources.Load("Materials/ColorTrees/Blue/Leaves 1", typeof(Material)) as Material;
                treeMat3 = Resources.Load("Materials/ColorTrees/Blue/Tree 1", typeof(Material)) as Material;
            }

            meshRenderer.material = treeMat1;

            newTree.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = treeMat2;
            newTree.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material = treeMat3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
