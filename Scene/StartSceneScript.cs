using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    public AudioSource se;
    public AudioClip bottan;
    bool Touch;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("count",1) ;
        PlayerPrefs.SetInt("food", 100);
        PlayerPrefs.SetInt("kaicount", 1);
        PlayerPrefs.SetInt("dethcount", 0);
        btn.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Touch==true)
        {
            Invoke("Delay", 2f);
        }
    }
    public void TouchButtonDown()
    {
        se.clip = bottan;
        se.Play();
        Touch = true;
        btn.interactable = false;
    }
    public void Delay()
    {
        SceneManager.LoadScene("GameStartScene");
    }
}
