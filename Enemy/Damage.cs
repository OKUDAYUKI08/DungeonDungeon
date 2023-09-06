using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public double EnemyHp = 5;
    public double PlayerattackDamage = 1;
    private Enemy enemy;
    public int dethcount;
    public GameObject StairEnemydeth;
    private SpriteRenderer spriteRenderer;
    StairEnemydethscript StairEnemydethscript;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
        StairEnemydeth = GameObject.FindWithTag("1");
        StairEnemydethscript = StairEnemydeth.GetComponent<StairEnemydethscript>();
    }
    public  void Update()
    {
        dethcount = PlayerPrefs.GetInt("dethcount");
        if (dethcount < 5)
        {
            PlayerattackDamage = 1;
        }
        if (dethcount >= 5)
        {
            PlayerattackDamage = 1.5;
        }
        if (dethcount >= 10)
        {
            PlayerattackDamage = 2;
        }
        if (dethcount >= 15)
        {
            PlayerattackDamage = 3;
        }
        if (dethcount >= 23)
        {
            PlayerattackDamage = 4;
        }
        if (dethcount >= 34)
        {
            PlayerattackDamage = 5;
        }
        if (dethcount >= 51)
        {
            PlayerattackDamage = 6;
        }
        if (dethcount >= 74)
        {
            PlayerattackDamage = 7;
        }
        StairEnemydethscript.attackDamage = PlayerattackDamage;
    }
    public void AttackDamage()
    {
        if (gameObject.CompareTag("Enemy1")||gameObject.CompareTag("Enemy2"))
        {
            EnemyHp-=PlayerattackDamage;
            if (EnemyHp <= 0)
            {
                enemy.Death();
            }
        }


    }
}
