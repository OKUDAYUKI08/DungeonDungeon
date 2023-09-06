using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float movetime = 0.1f;
    public bool isMoveing = false;

    public LayerMask blockingLayer;
    private BoxCollider2D boxCollider;
    public int RightMove;
    public int LeftMove;
    public int UpMove;
    public int UnderMove;


    public int horizontal;
    public int vertical;


    private Animator animator;

    private int food=100;
    public Text foodText;
    private int foodpoint = 10;
    private int sodapoint =20;

    public int kaicount = 1;

    public bool chopjuge;
    public bool foodjuge;
    public bool sodajuge;
    public bool Enemyattackjuge;
    public bool hitjuge;

    public double battlespeed=2;
    public double movespeed=0.3;

    GameObject btnManagerobject;
    ButtonManager btnManagerscript;

    public bool enemyhandan;//trueなら敵が倒れた

    public double speed;
    public int foot;
    GameObject footobject;
    GameObject dethobject;
    AudioSource footse;
    public int turncount;
    public AudioClip[] footclip;
    void Start()
    {

        food = PlayerPrefs.GetInt("food");
        kaicount = PlayerPrefs.GetInt("kaicount");
        rd2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        footobject = GameObject.Find("FootSEObject");
        footse = footobject.GetComponent<AudioSource>();

        
        PlayerPrefs.SetInt("Playerdeth", 0);
    }

    // Update is called once per frame


    void Update()
    {
        //speed = PlayerPrefs.GetFloat("speed");
        foot = PlayerPrefs.GetInt("foot");
        

        if (!GameManager2.instance.playerTurn)
        {
            return;
        }
        if (enemyhandan == true)
        {
            speed = movespeed;
            
        }


        //horizontal =(int)Input.GetAxisRaw("Horizontal")+RightMove + LeftMove;
        //vertical   =(int)Input.GetAxisRaw("Vertical")+ UnderMove + UpMove;
 

        if(horizontal!=0)
        {
            
            vertical = 0;
            if(horizontal==1)
            {
                transform.localScale=new Vector3(1, 1, 1);

            }
            else if(horizontal==-1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else if(vertical!=0)
        {
            horizontal = 0;
        }
        if (horizontal != 0 || vertical != 0)
        {
           ATMove(horizontal, vertical);
            horizontal = 0;
            vertical = 0;
        }

    }
   
    public void ATMove(int horizontal, int vertical)
    {
        turncount += 1;
        if (turncount == 5)
        {
            food--;
            turncount = 0;
        }
        
        foodText.text = "Food" + food;
        PlayerPrefs.SetInt("food", food);
        RaycastHit2D hit;
        if (foot != 0)
        {
            footse.clip = footclip[Random.Range(0, footclip.Length)];
            footse.Play();
        }

        bool canMove = Move(horizontal, vertical, out hit);


        if(hit.transform==null)
        {
            speed = movespeed;
            GameManager2.instance.playerTurn = false;
            return;
        }
        Damage hitConponent = hit.transform.GetComponent<Damage>();

        if(!canMove&&hitConponent!=null)
        {
            OncantMove(hitConponent);
            speed = battlespeed;
        }

        checkFood();
        GameManager2.instance.playerTurn = false;
    }
    
    public void OncantMove(Damage hit)
    {

        hit.AttackDamage();
        animator.SetTrigger("chop");
        chopjuge = true;
        speed = battlespeed;
        enemyhandan = false;
        footse.Stop();
        PlayerPrefs.SetInt("Playerhit", 1);

    }





    public bool Move(int horizontal,int vertical,out RaycastHit2D hit)
    {

        Vector2 start = transform.position;//現在地
        Vector2 end = start + new Vector2(horizontal, vertical);

        boxCollider.enabled = false;

        hit = Physics2D.Linecast(start, end, blockingLayer);

        boxCollider.enabled = true;

        if (!isMoveing && hit.transform==null )//移動中がtrue
        {
            speed = movespeed;
            StartCoroutine(Movement(end));
            return true;
        }
        return false;
    }

    IEnumerator Movement(Vector3 end)
    {
        isMoveing = true;

        float remainingDistance=(transform.position-end).sqrMagnitude;

        while(remainingDistance>float.Epsilon)//Epsilonは0に近い数字
        {
            transform.position = Vector3.MoveTowards(transform.position, end, 1f / movetime * Time.deltaTime);
            remainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
        transform.position = end;

        isMoveing = false;
        checkFood();
        
    }

    public void OnTriggerEnter2D(Collider2D collision)//trigerrとついたオブジェクトとぶつかった時に呼ばれる関数
    {
        if(collision.tag=="Food")
        {
            food += foodpoint;
            if(food>=100)
            {
                food = 100;
            }
            foodText.text = "Food" + food;
            PlayerPrefs.SetInt("food", food);
            collision.gameObject.SetActive(false);
            foodjuge = true;
        }
        else if(collision.tag=="Soda")
        {
            food += sodapoint;
            if (food >= 100)
            {
                food = 100;
            }
            foodText.text = "Food" + food;
            PlayerPrefs.SetInt("food", food);
            collision.gameObject.SetActive(false);
            sodajuge = true;
        }
        else if (collision.tag == "Exit")
        {
            PlayerPrefs.SetInt("food", food);
            kaicount += 1;
            if(kaicount==11)
            {

                Invoke("ClearDelay", 0.3f);
            }
            else
            {
                PlayerPrefs.SetInt("kaicount", kaicount);
                Invoke("levelload", 0.1f);

            }
            enabled = false;  
        }
        else if(collision.tag=="Exitdummy")
        {
            Invoke("TutorialDelay", 0.2f);
            PlayerPrefs.SetInt("dethcount", 0);

        }
    }
    public void Crear()
    {
        SceneManager.LoadScene(6);
    }
    public void TutorialDelay()
    {
        SceneManager.LoadScene(1);
    }

    public void ClearDelay()
    {
        SceneManager.LoadScene(6);
    }
    

    
    public void levelload()
    {
        PlayerPrefs.SetInt("food", food);
        SceneManager.LoadScene(4);
    }
    int a;
    public  void checkFood()
    {
        if(food<=0)
        {
            PlayerPrefs.SetInt("Playerdeth", 1);
            PlayerPrefs.SetInt("food", 0);
            PlayerPrefs.SetInt("Playerhit", 1);
            animator.SetTrigger("deth");
            Invoke("choidelay", 1.2f);
            a = 1;
            if (a == 1)
            {
                Invoke("GameOver", 1.4f);
                a = 0;
            }
        }
    }
    public void choidelay()
    {
        gameObject.SetActive(false);
    }
    public void GameOver()
    {
        GameManager2.instance.GameOver();
    }

    public void Enemyattack(int loss)
    {

        Invoke("Delay", 0.08f);
        food -= loss;
        PlayerPrefs.SetInt("food", food);
        checkFood();
        Enemyattackjuge = true;
        speed = battlespeed;

    }
    public int hitcount;
    public void Delay()
    {
        if (food >=0)
        {
            animator.SetTrigger("hit");
            
        }
        ;
        hitjuge = true;
        speed = battlespeed;
        PlayerPrefs.SetInt("Playerhit", 1);

    }
}


