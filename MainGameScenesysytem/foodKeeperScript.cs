using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class foodKeeperScript : MonoBehaviour
{
    public Text foodtext;
    public int foodcount;
    public GameObject foodcolor;
    public AudioSource dethbgm;
    Text foodcolorText;
    // Start is called before the first frame update
    public void Start()
    {
        foodcolorText = foodcolor.GetComponent<Text>();
    }

    // Update is called once per frame
    public void Update()
    {
        foodcount = PlayerPrefs.GetInt("food");
        if (foodcount == 0)
        {
            dethbgm.Play();
        }
        foodtext.text = foodcount.ToString();
        if (foodcount <= 20)
        {
            foodcolorText.color = Color.red;
        }
        else
        {
            foodcolorText.color = new Color(1, 1, 1, 1);
        }

    }

    

}
