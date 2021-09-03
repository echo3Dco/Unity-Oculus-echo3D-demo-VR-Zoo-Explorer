using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    public GameObject person;
    private void OnEnable() {
        GameObject newPerson = Instantiate(person);
        newPerson.transform.parent = transform;
        newPerson.transform.localPosition = new Vector3(0f, 0f, 0f);
        newPerson.transform.localRotation = Quaternion.identity;
        newPerson.transform.localScale = new Vector3(1f, 1f, 1f);
        /*
        for(int i = 0; i < transform.childCount; i++){
            GameObject newPerson = Instantiate(person);
            newPerson.transform.parent = transform.GetChild(i);
            newPerson.transform.localPosition = new Vector3(0f, 0f, 0f);
            newPerson.transform.localRotation = Quaternion.identity;
            newPerson.transform.localScale = new Vector3(1f, 1f, 1f);

            //MeshRenderer meshRenderer = newPerson.GetComponentInChildren<MeshRenderer>();

            //Material treeMat = Resources.Load("Materials/Black Wood", typeof(Material)) as Material;
            //meshRenderer.material = treeMat;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
