using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    private  GameObject aPlayer;
    public static ButtonManager instance;
    Player Playerscript;
    public bool RightMoving ;
    public bool LeftMoving ;
    public bool UpMoving ;
    public bool UnderMoving ;
    public Button rbtn;
    public Button underbtn;
    public Button upbtn;
    public Button leftbtn;
    public bool chop;
    public int Enemydeth;
    public int Playerhit;



    // Start is called before the first frame update
    void Start()
    {
        aPlayer = GameObject.FindGameObjectWithTag("Player");
        Playerscript = aPlayer.GetComponent<Player>();
    }
    private void Update()
    {
        Enemydeth = PlayerPrefs.GetInt("Enemydeth");
        if (Enemydeth == 1)
        {
            underbtn.interactable = true;
            rbtn.interactable = true;
            leftbtn.interactable = true;
            upbtn.interactable = true;
            Enemydeth = 0;
            PlayerPrefs.SetInt("Enemydeth", 0);
        }
        Playerhit = PlayerPrefs.GetInt("Playerhit");
        if (Playerhit == 1)
        {
            underbtn.interactable = false;
            rbtn.interactable = false;
            leftbtn.interactable = false;
            upbtn.interactable = false;
            PlayerPrefs.SetInt("Playerhit", 0);
            Invoke("Delay", 1f);
        }

    }
    public void Delay()
    {
        underbtn.interactable = true;
        rbtn.interactable = true;
        leftbtn.interactable = true;
        upbtn.interactable = true;
    }

    public void RightButtonDown()
    {
        Playerscript.horizontal = 1;
        Invoke("Delay", (float)Playerscript.speed);
        
        PlayerPrefs.SetInt("foot",1);
        //RightMoving = true;

    }
    public void RightButtonUp()
    {
        //RightMoving = false;
        Playerscript.horizontal = 0;
    }
    public void LeftButtonDown()
    {
        //LeftMoving = true;
        Playerscript.horizontal = -1;
        Invoke("Delay", (float)Playerscript.speed);
        PlayerPrefs.SetInt("foot", 1);
    }
    public void LeftButtonUp()
    {
        //LeftMoving = false;
        Playerscript.horizontal = 0;
    }

    public void UpButtonDown()
    {
        //UpMoving = true;
        Playerscript.vertical = 1;
        Invoke("Delay", (float)Playerscript.speed);
        PlayerPrefs.SetInt("foot", 1);
    }
    public void UpButtonUp()
    {
        //UpMoving = false;
        Playerscript.vertical = 0;
    }

    public void UnderDown()
    {
        //UnderMoving = true;
        Playerscript.vertical = -1;
        Invoke("Delay", (float)Playerscript.speed);
        PlayerPrefs.SetInt("foot", 1);
    }
    public void UnderUp()
    {
        //UnderMoving = false;
        Playerscript.vertical = 0;
    }
    /*
private void Update()
{

    if (RightMoving == true)
    {
        Playerscript.horizontal = 1;
    }
    else 
    {
        Playerscript.horizontal = 0;
    }
    if (LeftMoving == true)
    {
        Playerscript.horizontal = -1;
    }
    else //if (LeftMoving == false)
    {
        Playerscript.horizontal = 0;
    }
    if (UpMoving == true)
    {
        Playerscript.vertical = 1;
    }
    else //if (UpMoving == false)
    {
        Playerscript.vertical = 0;
    }
    if (UnderMoving == true)
    {
        Playerscript.vertical = -1;
    }
    else //if (UnderMoving == false)
    {
        Playerscript.vertical = 0;
    }

}
*/
}
