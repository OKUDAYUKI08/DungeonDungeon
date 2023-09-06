using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titlebgm : MonoBehaviour
{
    AudioSource Title;
    public GameObject bottan;
    bool Startbottan;

    // Start is called before the first frame update
    void Start()
    {
        Title = this.gameObject.GetComponent<AudioSource>();
        Title.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (Startbottan == true)
        {
            Title.Stop();
        }
    }
    public void Bottan()
    {
        Startbottan = true;
    }
}
