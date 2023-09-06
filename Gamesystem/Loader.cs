using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;

    public void Awake()
    {
        if(GameManager2.instance==null)
        {
            Instantiate(gameManager);
        }
    }
}
