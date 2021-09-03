using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TigerPointSystem : MonoBehaviour
{
    public int score;
    public int randomNumber;
    public GameObject pointer;
    public Coroutine winState;
    public TMP_Text pointTracker;

    private void OnEnable() {
        randomNumber = Random.Range(0,5);
        for(int i = 0; i < transform.childCount; i++){
            GameObject newTree = Instantiate(pointer);
            newTree.transform.parent = transform.GetChild(i);
            newTree.transform.localPosition = new Vector3(0f, 0f, 0f);
            newTree.transform.localRotation = Quaternion.identity;
            newTree.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            if(i != randomNumber){
                transform.GetChild(i).gameObject.SetActive(false);
            }

            MeshRenderer meshRenderer = newTree.GetComponentInChildren<MeshRenderer>();

            //Material treeMat = Resources.Load("Materials/Black Wood", typeof(Material)) as Material;
            //meshRenderer.material = treeMat;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 5){
            winState = StartCoroutine(GoBackToOverworld());
        }
    }

    public void GetPoint(){
        score++;
        if(score == 1){
            pointTracker.text = "4 CARROTS REMAINING";
        }
        else if(score == 2){
            pointTracker.text = "3 CARROTS REMAINING";
        }
        else if(score == 3){
            pointTracker.text = "2 CARROTS REMAINING";
        }
        else if(score == 4){
            pointTracker.text = "1 CARROT REMAINING";
        }
        else if(score == 5){
            pointTracker.text = "ALL CARROTS PLUCKED\nGREAT JOB!";
        }
        int tempRandomNumber = Random.Range(0, 5);
        while(randomNumber == tempRandomNumber){
            tempRandomNumber = Random.Range(0,5);
        }
        transform.GetChild(randomNumber).gameObject.SetActive(false);
        randomNumber = tempRandomNumber;
        if(score != 5){
            transform.GetChild(randomNumber).gameObject.SetActive(true);
        }
    }

    IEnumerator GoBackToOverworld(){
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
