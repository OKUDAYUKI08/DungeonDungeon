using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountScript : MonoBehaviour
{
    systemManager systemManagerscript;
    GameObject Camera;
    GameObject gameManagerObject;
    Loader LoaderScript;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        LoaderScript=Camera.GetComponent<Loader>();
        gameManagerObject = LoaderScript.gameManager;
        systemManagerscript = gameManagerObject.GetComponent<systemManager>();

    }

    // Update is called once per frame
    void Update()
    {
        systemManagerscript.kaicount = PlayerPrefs.GetInt("kaicount");
    }
}
