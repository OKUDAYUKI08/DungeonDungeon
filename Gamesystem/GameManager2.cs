using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance;
    systemManager systemManager;
    Nextlevelscript Nextlevelscript;

    public bool playerTurn = true;
    public bool enemiesMoving= false;

    public int level = 1;
    private bool doingSetup;
    public Text levelText;
    public GameObject levelImage;

    private List<Enemy> enemies;


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
        enemies = new List<Enemy>();

        systemManager = GetComponent<systemManager>();
        Nextlevelscript= GetComponent<Nextlevelscript>();
        InitGame();
    }



    public void InitGame()
    {
        systemManager.kaicount=PlayerPrefs.GetInt("kaicount");
        systemManager.SetUpScene();
        doingSetup = true;

        enemies.Clear();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTurn||enemiesMoving)
        {
            return;
        }
        StartCoroutine(MoveEnemies());
    }

    public void AddEnemy(Enemy script)
    {
        enemies.Add(script);
    }
    public void DestoryEnemy(Enemy script)
    {
        enemies.Remove(script);
    }
    


    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;

        yield return new WaitForSeconds(0.1f);

        if(enemies.Count==0)
        {
            yield return new WaitForSeconds(0.1f);

        }
        for(int i=0;i<enemies.Count;i++)
        {
            enemies[i].MoveEnemy();
        }

        yield return new WaitForSeconds(0.1f);

        playerTurn = true;

        enemiesMoving = false;

    }
    
    public void GameOver()
    {
        SceneManager.LoadScene(5);

    }
    
}
