using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nextlevelscript : MonoBehaviour
{
    public static int count;

    public Text countText;
    public Text kai;


    // Start is called before the first frame update
    public void Start()
    {
        count = PlayerPrefs.GetInt("kaicount");
        countText.text = count.ToString();
        
        Invoke("Next", 1.5f);

    }
    public void Next()
    {
        SceneManager.LoadScene(3);
    }


}
