using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SingleEchoSelection : MonoBehaviour
{
    public EchoList[] FullList;
    private VideoechoAR echo;

    private bool initialize;
    private Transform holder;
    private GameLoader gameLoader;


    void Awake()
    {
        echo = this.GetComponent<VideoechoAR>();
        initialize = false;

        holder = GameObject.FindGameObjectWithTag("holder").transform;
        this.transform.GetChild(0);

        for (int i = 0; i < FullList.Length; i++)
        {
            GameObject obj = new GameObject();
            obj.transform.SetParent(holder);
            obj.name = FullList[i].index.ToString();
        }

        gameLoader = GameObject.FindGameObjectWithTag("loader").GetComponent<GameLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (echo.fetched && !initialize && gameLoader.loaded && !gameLoader.turnedOff)
        {
            StartFetchingVedios();
            initialize = true;
        }
        else
        {
            foreach (Transform trans in this.transform)
            {
                VideoPlayer vp = trans.gameObject.GetComponent<VideoPlayer>();
                if (vp != null)
                    vp.enabled = false;
                
                MeshRenderer mr = trans.gameObject.GetComponent<MeshRenderer>();
                if (mr != null)
                    mr.enabled = false;
            }
        }

    }

    public bool isInList(string indexStr)
    {
        bool inList = false;
        foreach (Transform hold in holder)
        {
            if (hold.name.Equals(indexStr))
                return true;
        }
        return inList;
    }

    void StartFetchingVedios()
    {
        //yield return new WaitForSeconds(0.1f);

        holder.SetAsFirstSibling();

        for (int i = 1; i < this.transform.childCount; i++)
        {
            GameObject obj = this.transform.GetChild(i).gameObject;

            RemoteTransformations rt = obj.GetComponent<RemoteTransformations>();
            int index = rt.Index;


            Transform hold = holder.Find(index.ToString());
            if (hold != null)
            {
                obj.transform.SetParent(holder);
                int sibIndex = hold.GetSiblingIndex();
                hold.SetParent(this.transform);
                hold.SetSiblingIndex(obj.transform.GetSiblingIndex());
                obj.transform.SetSiblingIndex(sibIndex);

                VideoProperty property = obj.AddComponent<VideoProperty>();
                property.mesh = FullList[sibIndex].mesh;
                property.looping = FullList[sibIndex].looping;
                property.mute = FullList[sibIndex].mute;
                property.playAwake = FullList[sibIndex].playOnAwake;
                property.volume = FullList[sibIndex].volume;
            }
            else
            {
                obj.SetActive(false);
            }

        }
    }
}

[System.Serializable]
public class EchoList
{
    public int index = 0;
    public bool playOnAwake = false;
    public bool looping = false;
    public bool mute = false;
    public bool mesh = false;
    public float volume = 1.0f;

}
