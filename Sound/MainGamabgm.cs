using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGamabgm : MonoBehaviour
{
    public AudioSource bgm;
    public AudioClip firstbgm;
    public AudioClip secondbgm;
    public AudioClip Finalbgm;
  

    


    int kaicount;
    int dethjuge;
    int a;
    
    // Start is called before the first frame update
    void Start()
    {
        a = 0;
        kaicount = PlayerPrefs.GetInt("kaicount");
        if (kaicount >= 5)
        {
            if (kaicount == 10)
            {
                bgm.clip = Finalbgm;
                bgm.volume = 0.6f;
                bgm.Play();
            }
            else
            {
                bgm.clip = secondbgm;
                bgm.Play();
            }
        }
        else if (kaicount < 5)
        {
            bgm.clip = firstbgm;
            bgm.Play();
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        dethjuge = PlayerPrefs.GetInt("Playerdeth");
        if (dethjuge == 1)
        {
            bgm.Stop();
            a = 1;
        }


    }
}
