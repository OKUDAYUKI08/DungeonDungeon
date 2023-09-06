using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class systemManager : MonoBehaviour
{
    public int MapWidth = 50;
    public int MapHeight = 50;

    int[,] Map;

    public int wall = 9;
    public int road = 0;
    public int roomMinHeight = 5;
    public int roomMaxHeight = 10;

    public int roomMinWidth = 5;
    public int roomMaxWidth = 10;

    public int RoomCountMin = 10;
    public int RoomCountMax = 15;

    public int foodMinimum = 3, foodMaximum = 4;

    public int Enemy1Minimum = 10,Enemy1Maximum = 10;
    public int Enemy2Minimum = 10, Enemy2Maximum = 10;
    public int kaicount;

    public int meetPointCount = 1;
    GameObject cPlayer;
    Player Playerscript;

    public GameObject[] WallObject;
    public GameObject[] FloorObject;
    public GameObject[] foodTiles;
    public GameObject[] sodaTiles;
    public GameObject[] Exit;
    public GameObject[] Player;
    public GameObject[] Enemy1;
    public GameObject[] Enemy2;
    public GameObject[] Enemy3;

    public void Start()
    {
        cPlayer = GameObject.FindGameObjectWithTag("Player");
        Playerscript = cPlayer.GetComponent<Player>();
        kaicount = PlayerPrefs.GetInt("kaicount");
    }





    public void SetUpScene()
    {
        ResetMapData();

        CreateSpaceData();

        CreateDangeon();
    }


    /// <summary>
    /// Mapの二次元配列の初期化
    /// </summary>
    private void ResetMapData()
    {
        Map = new int[MapHeight, MapWidth];
        for (int i = 0; i < MapHeight; i++)
        {
            for (int j = 0; j < MapWidth; j++)
            {
                Map[i, j] = wall;
            }
        }
    }

    /// <summary>
    /// 空白部分のデータを変更
    /// </summary>
    private void CreateSpaceData()
    {
        int roomCount = Random.Range(RoomCountMin, RoomCountMax);

        int[] meetPointsX = new int[meetPointCount];
        int[] meetPointsY = new int[meetPointCount];
        for (int i = 0; i < meetPointsX.Length; i++)
        {
            meetPointsX[i] = Random.Range(MapWidth / 4, MapWidth * 3 / 4);
            meetPointsY[i] = Random.Range(MapHeight / 4, MapHeight * 3 / 4);
            Map[meetPointsY[i], meetPointsX[i]] = road;
        }

        for (int i = 0; i < roomCount; i++)
        {
            int roomHeight = Random.Range(roomMinHeight, roomMaxHeight);
            int roomWidth = Random.Range(roomMinWidth, roomMaxWidth);
            int roomPointX = Random.Range(2, MapWidth - roomMaxWidth - 2);
            int roomPointY = Random.Range(2, MapWidth - roomMaxWidth - 2);

            int roadStartPointX = Random.Range(roomPointX, roomPointX + roomWidth);
            int roadStartPointY = Random.Range(roomPointY, roomPointY + roomHeight);

            bool isRoad = CreateRoomData(roomHeight, roomWidth, roomPointX, roomPointY);

            if (isRoad == false)
            {
                CreateRoadData(roadStartPointX, roadStartPointY, meetPointsX[Random.Range(0, 0)], meetPointsY[Random.Range(0, 0)]);
            }
        }


    }

    /// <summary>
    /// 部屋データを生成。すでに部屋がある場合はtrueを返し、道を作らないようにする
    /// </summary>
    /// <param name="roomHeight">部屋の高さ</param>
    /// <param name="roomWidth">部屋の横幅</param>
    /// <param name="roomPointX">部屋の始点(x)</param>
    /// <param name="roomPointY">部屋の始点(y)</param>
    /// <returns></returns>
    private bool CreateRoomData(int roomHeight, int roomWidth, int roomPointX, int roomPointY)
    {
        bool isRoad = false;
        for (int i = 0; i < roomHeight; i++)
        {
            for (int j = 0; j < roomWidth; j++)
            {
                if (Map[roomPointY + i, roomPointX + j] == road)
                {
                    isRoad = true;
                }
                else
                {
                    Map[roomPointY + i, roomPointX + j] = road;
                }
            }
        }
        return isRoad;
    }

    /// <summary>
    /// 道データを生成
    /// </summary>
    /// <param name="roadStartPointX"></param>
    /// <param name="roadStartPointY"></param>
    /// <param name="meetPointX"></param>
    /// <param name="meetPointY"></param>
    private void CreateRoadData(int roadStartPointX, int roadStartPointY, int meetPointX, int meetPointY)
    {

        bool isRight;
        if (roadStartPointX > meetPointX)
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }
        bool isUnder;
        if (roadStartPointY > meetPointY)
        {
            isUnder = false;
        }
        else
        {
            isUnder = true;
        }

        if (Random.Range(0, 2) == 0)
        {

            while (roadStartPointX != meetPointX)
            {

                Map[roadStartPointY, roadStartPointX] = road;
                if (isRight == true)
                {
                    roadStartPointX--;
                }
                else
                {
                    roadStartPointX++;
                }

            }

            while (roadStartPointY != meetPointY)
            {

                Map[roadStartPointY, roadStartPointX] = road;
                if (isUnder == true)
                {
                    roadStartPointY++;
                }
                else
                {
                    roadStartPointY--;
                }
            }

        }
        else
        {

            while (roadStartPointY != meetPointY)
            {

                Map[roadStartPointY, roadStartPointX] = road;
                if (isUnder == true)
                {
                    roadStartPointY++;
                }
                else
                {
                    roadStartPointY--;
                }
            }

            while (roadStartPointX != meetPointX)
            {

                Map[roadStartPointY, roadStartPointX] = road;
                if (isRight == true)
                {
                    roadStartPointX--;
                }
                else
                {
                    roadStartPointX++;
                }

            }

        }
    }

    public void LayoutobjectRandom(GameObject[]tileArray,int min,int max)
    {
        int i = 0;
        int count = 0;
        int objectCount = Random.Range(min, max+1);
        for (i = 0;i< objectCount;i++)
        {
            int pointx = Random.Range(0, MapHeight);
            int pointy = Random.Range(0, MapHeight);
            if (Map[pointx, pointy] == road)
            {
                GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
                Instantiate(tileChoice, new Vector3(pointy- MapWidth / 2, pointx- MapHeight / 2, 0), Quaternion.identity);
                count = count+1;
            }
            if(Map[pointx, pointy]==wall)
            {
                i = i-1;
                continue;
            }
            if (count == objectCount)
            {
                break;
            }
            



        }
    }
    


    /// <summary>
    /// マップデータをもとにダンジョンを生成
    /// </summary>
    public void CreateDangeon()
    {
        for (int i = 0; i < MapHeight; i++)
        {
            for (int j = 0; j < MapWidth; j++)
            {
                GameObject toInstantiatewall;
                toInstantiatewall=WallObject[Random.Range(0,WallObject.Length)];
                GameObject toInstantiatefloor;
                toInstantiatefloor = FloorObject[Random.Range(0, FloorObject.Length)];
                if (Map[i, j] == wall)
                {
                    Instantiate(toInstantiatewall, new Vector3(j - MapWidth / 2, i - MapHeight / 2, 0), Quaternion.identity);
                }
                else if(Map[i,j]==road)
                {
                    Instantiate(toInstantiatefloor, new Vector3(j - MapWidth / 2, i - MapHeight / 2, 0), Quaternion.identity);
                    
                }
            }
        }
        LayoutobjectRandom(foodTiles, foodMinimum, foodMaximum);
        LayoutobjectRandom(Exit, 1, 1);
        LayoutobjectRandom(Player, 1, 1);
        
        if (kaicount<5)
        {
            LayoutobjectRandom(Enemy1, 5, 6);
        }
        if(kaicount>=5)
        {
            
            LayoutobjectRandom(Enemy1, 4, 5);
            if ( kaicount<=6)
            {
                LayoutobjectRandom(Enemy2, 3, 3);
                LayoutobjectRandom(sodaTiles, 3, 4);
            }
            else if (kaicount <= 8)
            {
                LayoutobjectRandom(Enemy2, 5, 5);
                LayoutobjectRandom(sodaTiles, 3, 4);
            }
            else if (kaicount <= 10)
            {
                LayoutobjectRandom(Enemy3, 7, 7);
                LayoutobjectRandom(sodaTiles, 1, 2);
            }
        }


    }
}
