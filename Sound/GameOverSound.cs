using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSound : MonoBehaviour
{
    AudioSource GameOverAudio;
    // Start is called before the first frame update
    void Start()
    {
        GameOverAudio= this.gameObject.GetComponent<AudioSource>();
        GameOverAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
