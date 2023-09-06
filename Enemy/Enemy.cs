using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject aPlayer;
    Player Playerscript;
    public float movetime = 0.1f;
    public bool isMoveing = false;
    public int dethcount;
    public LayerMask blockingLayer;
    private BoxCollider2D boxCollider;
    public int attackDamage = 0;//後で必ず直す・・・
    private Animator animator;
    private Transform target;
    public string Enemyname; 
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        GameManager2.instance.AddEnemy(this);
    }
    void Update()
    {
        dethcount = PlayerPrefs.GetInt("dethcount");
    }
    public void   ATMove(int horizontal, int vertical)
    {

        RaycastHit2D hit;

        bool canMove = Move(horizontal, vertical, out hit);

        if (hit.transform == null)
        {
            return;
        }
        Player hitConponent = hit.transform.GetComponent<Player>();

        if (!canMove && hitConponent != null)
        {

            OncantMove(hitConponent);
        }

    }


    public bool Move(int horizontal, int vertical, out RaycastHit2D hit)
    {

        Vector2 start = transform.position;//現在地
        Vector2 end = start + new Vector2(horizontal, vertical);

        boxCollider.enabled = false;

        hit = Physics2D.Linecast(start, end, blockingLayer);

        boxCollider.enabled = true;

        if (!isMoveing && hit.transform == null)//移動中がtrue
        {
            StartCoroutine(Movement(end));
            return true;
        }
        return false;
    }

    IEnumerator Movement(Vector3 end)
    {
        isMoveing = true;

        float remainingDistance = (transform.position - end).sqrMagnitude;

        while (remainingDistance > float.Epsilon)//Epsilonは0に近い数字
        {
            transform.position = Vector3.MoveTowards(transform.position, end, 1f / movetime * Time.deltaTime);
            remainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
        transform.position = end;

        isMoveing = false;

    }
    public void OncantMove(Player hit)
    {
        hit.Enemyattack(attackDamage);

        animator.SetTrigger("Enemy1_attack");
    }
    public void Death()
    {
        if(gameObject.CompareTag("Enemy1"))
        {
            dethcount += 1;
        }
        if (gameObject.CompareTag("Enemy2"))
        {
            dethcount += 2;
        }

        Debug.Log(dethcount);
        PlayerPrefs.SetInt("dethcount", dethcount);
        GameManager2.instance.DestoryEnemy(this);
        animator.SetTrigger("Deth");
        Invoke("Delay", 0.5f);
        PlayerPrefs.SetInt("Enemydeth", 1);
    }
    public void Delay()
    {

        gameObject.SetActive(false);
    }

    public void MoveEnemy()
    {
        int xdir = 0;
        int ydir = 0;
        
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1);
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, 1);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1);

        if (hitright.collider.tag == "Wall"&& Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
        {
            xdir = 0;
            ydir = target.position.y > transform.position.y ? 1 : -1;
        }
        if (hitleft.collider.tag == "Wall"&& Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
        {
            xdir = 0;
            ydir = target.position.y > transform.position.y ? 1 : -1;
        }
        if (hitup.collider.tag == "Wall"&&Mathf.Abs(target.position.x - transform.position.x) >= float.Epsilon)
        {
            ydir = 0;
            xdir = target.position.x > transform.position.x ? 1 : -1;
        }
        if (hitdown.collider.tag == "Wall"&& Mathf.Abs(target.position.x - transform.position.x) >= float.Epsilon)
        {
            ydir = 0;
            xdir = target.position.x > transform.position.x ? 1 : -1;
        }
        
        
        if (Mathf.Abs(target.position.x-transform.position.x)<float.Epsilon)
        {
            ydir = target.position.y > transform.position.y ? 1 : -1;
        }
        else if(Mathf.Abs(target.position.x - transform.position.x) >= float.Epsilon)
        {
            xdir = target.position.x > transform.position.x ? 1 : -1;
        }
        



        ATMove(xdir, ydir);


    }



}
