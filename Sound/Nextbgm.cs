using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextbgm : MonoBehaviour
{
    AudioSource kaidan;
    // Start is called before the first frame update
    void Start()
    {
        kaidan = this.gameObject.GetComponent<AudioSource>();
        kaidan.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
