using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ClearScript : MonoBehaviour
{
    public AudioSource Clearse;
    public AudioClip Clearclip;
    // Start is called before the first frame update
    void Start()
    {
        Clearse.clip = Clearclip;
        Clearse.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button()
    {
        Re();
    }
    public void Re()
    {
        SceneManager.LoadScene(0);
    }
}
