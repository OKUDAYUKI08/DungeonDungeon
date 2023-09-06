using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titlerainsound : MonoBehaviour
{
    public AudioSource bgm;
    public AudioClip rain;
    // Start is called before the first frame update
    void Start()
    {
        bgm.clip = rain;
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
