using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] audios;
    // Start is called before the first frame update
    public void Play(int audio)
    {
        GetComponent<AudioSource>().PlayOneShot(audios[audio]);
    }
}
