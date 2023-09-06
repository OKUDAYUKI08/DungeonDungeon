using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StairEnemydethscript : MonoBehaviour
{
    public Text stairtext;
    public Text Enemytext;
    public Text attack;
    public int kaicount;
    public int dethcount;
    public double attackDamage;
    public GameObject EnemyObject;
    Damage DamageScript;

    public void Start()
    {
        kaicount= PlayerPrefs.GetInt("kaicount");
        stairtext.text ="B"+kaicount.ToString();
        EnemyObject = GameObject.FindGameObjectWithTag("Enemy1");
        DamageScript = EnemyObject.GetComponent<Damage>();
    }
    public void Update()
    {
        dethcount = PlayerPrefs.GetInt("dethcount");
        Enemytext.text = "EXP:"+dethcount.ToString();
        attackDamage = DamageScript.PlayerattackDamage;
        attack.text = "ATKP:" + attackDamage.ToString();
    }

}
