using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public Material material;
    public float speed = 0.05f;
    private float _offset;

    // Use this for initialization
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _offset += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
    }

    public void ParaParalax()
    {
        speed = 0;
    }

    public void ContinuaParalax()
    {
        speed = 0.05f;
    }
}
