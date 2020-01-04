using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeAudios : MonoBehaviour
{
    [SerializeField] float volume;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("VolumeAudios");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            volume = AudioListener.volume + 0.1f;
            if (volume <= 1)
            {
                AudioListener.volume = volume;
            }
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            volume = AudioListener.volume - 0.1f;
            if (volume >= 0)
            {
                AudioListener.volume = volume;
            }
        }
    }
}
