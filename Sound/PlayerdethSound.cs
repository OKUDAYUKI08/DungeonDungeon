using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerdethSound : MonoBehaviour
{
    public int dethjuge;
    public AudioSource dethse;
    public AudioClip dethclip;
    // Start is called before the first frame update
    void Start()
    {
        dethse.clip = dethclip;
    }
    void Update()
    {
        dethjuge = PlayerPrefs.GetInt("Playerdeth");
        if (dethjuge == 1)
        {
            Debug.Log(dethjuge);
            dethse.Play();
        }
    }
}
