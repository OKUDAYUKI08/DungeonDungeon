using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sebgm : MonoBehaviour
{
    private GameObject aPlayer;
    Player Playerscript;
    public AudioSource se;

    public AudioClip Playerchop;
    public AudioClip food;
    public AudioClip Enemychop;
    public AudioClip Soda;

    // Start is called before the first frame update
    void Start()
    {
        aPlayer = GameObject.FindGameObjectWithTag("Player");
        Playerscript = aPlayer.GetComponent<Player>();
    }

    public void PlaySingle(AudioClip clip)
    {
        se.clip = clip;
        se.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Playerscript.chopjuge == true)
        {
            PlaySingle(Playerchop);
            Playerscript.chopjuge = false;
        }
        if (Playerscript.foodjuge == true)
        {
            PlaySingle(food);
            Playerscript.foodjuge = false;
        }
        if (Playerscript.Enemyattackjuge)
        {
            Invoke("Enemyattack", 0.4f);
        }
        if (Playerscript.sodajuge == true)
        {
            PlaySingle(Soda);
            Playerscript.sodajuge = false;
        }

    }

    public void Enemyattack()
    {
        if (Playerscript.Enemyattackjuge == true)
        {
            PlaySingle(Enemychop);
            Playerscript.Enemyattackjuge = false;
        }
    }
}
