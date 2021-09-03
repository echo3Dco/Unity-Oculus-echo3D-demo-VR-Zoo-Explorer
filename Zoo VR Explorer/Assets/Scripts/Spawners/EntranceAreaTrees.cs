using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceAreaTrees : MonoBehaviour
{
    public GameObject tree;

    private void OnEnable() {
        for(int i = 0; i < transform.childCount; i++){
            GameObject newTree = Instantiate(tree);
            newTree.transform.parent = transform.GetChild(i);
            newTree.transform.localPosition = new Vector3(0f, 0f, 0f);
            newTree.transform.localRotation = Quaternion.identity;
            newTree.transform.localScale = new Vector3(1f, 1f, 1f);

            MeshRenderer meshRenderer = newTree.GetComponentInChildren<MeshRenderer>();

            if(i == 0 || i == 4 || i == 5 || i == 6 || i == 8 || i == 14 || i == 15){
                Material treeMat = Resources.Load("Materials/Free_Tree 1", typeof(Material)) as Material;
                meshRenderer.material = treeMat;
            }
            else if(i == 9 || i == 10 || i == 11 || i == 13 || i == 19){
                Material treeMat = Resources.Load("Materials/Free_Tree 2", typeof(Material)) as Material;
                meshRenderer.material = treeMat;
            }
            else if(i == 23 || i == 22){
                Material treeMat = Resources.Load("Materials/Free_Tree 3", typeof(Material)) as Material;
                meshRenderer.material = treeMat;
            }
            else if (i >= 24 && i <= 38){
                int randomNumber = Random.Range(0,2);
                if(randomNumber == 1){
                    Material treeMat = Resources.Load("Materials/Free_Tree 4", typeof(Material)) as Material;
                    meshRenderer.material = treeMat;
                }
                else{
                    Material treeMat = Resources.Load("Materials/Free_Tree 5", typeof(Material)) as Material;
                    meshRenderer.material = treeMat;
                }
            }
            else if (i >= 29 && i <= 53){
                int randomNumber = Random.Range(0,2);
                if(randomNumber == 1){
                    Material treeMat = Resources.Load("Materials/Free_Tree 1", typeof(Material)) as Material;
                    meshRenderer.material = treeMat;
                }
                else{
                    Material treeMat = Resources.Load("Materials/Free_Tree 6", typeof(Material)) as Material;
                    meshRenderer.material = treeMat;
                }
            }
            else if (i >= 54 && i <= 61){
                int randomNumber = Random.Range(0,2);
                if(randomNumber == 1){
                    Material treeMat = Resources.Load("Materials/Free_Tree 7", typeof(Material)) as Material;
                    meshRenderer.material = treeMat;
                }
                else{
                    Material treeMat = Resources.Load("Materials/Free_Tree 8", typeof(Material)) as Material;
                    meshRenderer.material = treeMat;
                }
            }
            else if (i >= 62 && i <= 70){
                int randomNumber = Random.Range(0,2);
                if(randomNumber == 1){
                    Material treeMat = Resources.Load("Materials/Free_Tree 9", typeof(Material)) as Material;
                    meshRenderer.material = treeMat;
                }
                else{
                    Material treeMat = Resources.Load("Materials/Free_Tree 10", typeof(Material)) as Material;
                    meshRenderer.material = treeMat;
                }
            }
            else{
                Material treeMat = Resources.Load("Materials/Free_Tree", typeof(Material)) as Material;
                meshRenderer.material = treeMat;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
