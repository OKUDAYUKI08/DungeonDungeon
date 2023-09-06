using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("count", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }
}
