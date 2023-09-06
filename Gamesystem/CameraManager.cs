using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    private GameObject Player;
    private Player player;
    private void Start()
    {

        Invoke("DelayMethod", 0.0001f);
    }

    void DelayMethod()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

        Vector3 position = Player.transform.position;
        Vector3 PlayerPos = position;
        transform.position = new Vector3(PlayerPos.x, PlayerPos.y,PlayerPos.z-1 );
    }
}