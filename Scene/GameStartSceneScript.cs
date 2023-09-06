using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartSceneScript : MonoBehaviour
{
    bool MainGame;
    bool Tutorial;
    bool kankaku;
    public AudioSource chonse;
    public AudioSource rainbgm;
    public AudioSource bgm;
    public AudioClip chon;
    public AudioClip rain;
    public AudioClip space;
    public AudioSource Startse;
    public AudioClip Startclip;
    public AudioClip Tutorialclip;
    public AudioSource Tutorialse;
    public Button mainstartbtn;
    public Button tutorialbtn;

    int Ran;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delay", 1f);
        rainbgm.clip = rain;
        rainbgm.Play();
        bgm.clip = space;
        bgm.Play();

        
    }
    public void Bgmstop()
    {
        bgm.Stop();
        rainbgm.Stop();
        chonse.Stop();
    }
    public void Delay()
    {
        kankaku = true;
    }
    public void chonsound()
    {
        chonse.clip = chon;
        chonse.Play();
        kankaku=true;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (kankaku == true)
        {
            kankaku=false;
            Ran = Random.Range(3, 6);
            Invoke("chonsound", Ran);
        }

        if (MainGame == true)
        {
            mainstartbtn.interactable = false;
            tutorialbtn.interactable = false;
            Invoke("StartGame", 2.5f);

        }


        if (Tutorial==true)
        {
            tutorialbtn.interactable = false;
            mainstartbtn.interactable = false;
            Invoke("StartTutorial", 1.5f);
            
        }
    }
    public void GameStartSceneButtonDown()
    {
        Bgmstop();
        Startse.clip = Startclip;
        Startse.Play();
        MainGame = true;
    }
    public void TutorialSceneButtonDown()
    {
        Bgmstop();
        Tutorialse.clip = Tutorialclip;
        Tutorialse.Play();
        Tutorial = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene("TutorialGameScene");
    }
}
