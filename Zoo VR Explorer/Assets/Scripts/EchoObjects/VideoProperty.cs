using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoProperty : MonoBehaviour
{
    MeshRenderer mr;
    VideoPlayer vp;

    public bool mesh, playAwake, looping, mute;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        mr = gameObject.GetComponent<MeshRenderer>();
        mr.enabled = mesh;
        gameObject.GetComponent<MeshCollider>().enabled = mesh;

        vp = gameObject.GetComponent<VideoPlayer>();
        vp.enabled = true;
        vp.playOnAwake = playAwake;
        if (!vp.playOnAwake)
            vp.Pause();

        vp.isLooping = looping;
        vp.SetDirectAudioMute(0, mute);
        vp.SetDirectAudioVolume(0, volume);
    }

    // Update is called once per frame
    void Update()
    {
        if (mesh && vp.isPlaying)
            mr.enabled = true;
        else if (mesh && !vp.isPlaying)
        {
            mr.enabled = false;
            Debug.Log("try playing");
            vp.Play();
        }
    }

}
