using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private static TileManager instanse;
    public static TileManager Instanse
    {
        get
        {
            if(instanse == null)
            {
                instanse = FindObjectOfType<TileManager>();
            }

            return instanse;
        }
    }


    private Stack<GameObject> leftTiles = new Stack<GameObject>();
    public Stack<GameObject> LeftTiles
    {
        get
        {
            return leftTiles;
        }

        set
        {
            leftTiles = value;
        }
    }

    private Stack<GameObject> topTiles = new Stack<GameObject>();
    public Stack<GameObject> TopTiles
    {
        get
        {
            return topTiles;
        }

        set
        {
            topTiles = value;
        }
    }

    [SerializeField] private GameObject[] tilePrefabs;

    [SerializeField] private GameObject CurrentTile;


    private void Awake()
    {
        if (instanse)
        {
            DestroyImmediate(this);
        }
        else
        {
            instanse = this;
        }
    }
    private void Start()
    {
        TileCreate(20);

        for(int i = 0; i < 10; i++)
        {
            TileSpawn();
        }
    }

    public void TileCreate(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            leftTiles.Push(Instantiate(tilePrefabs[0]));
            TopTiles.Push(Instantiate(tilePrefabs[1]));
            leftTiles.Peek().SetActive(false);
            leftTiles.Peek().name = "LeftTile";
            TopTiles.Peek().SetActive(false);
            TopTiles.Peek().name = "TopTile";
        }
    }

    public void TileSpawn()
    {
        if(leftTiles.Count == 0 || TopTiles.Count == 0)
        {
            TileCreate(10);
        }

        int randomTileIndex = Random.Range(0, tilePrefabs.Length);

        if(randomTileIndex == 0)
        {
            GameObject tmp = leftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = CurrentTile.transform.GetChild(0).transform.GetChild(randomTileIndex).position;
            CurrentTile = tmp;
        }
        else if(randomTileIndex == 1)
        {
            GameObject tmp = TopTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = CurrentTile.transform.GetChild(0).transform.GetChild(randomTileIndex).position;
            CurrentTile = tmp;
        }

        int spawnPickUp = Random.Range(0, 10);

        if(spawnPickUp == 0)
        {
            CurrentTile.transform.GetChild(1).gameObject.SetActive(true);
        }

        //CurrentTile = (GameObject)Instantiate(tilePrefabs[randomTileIndex], CurrentTile.transform.GetChild(0).transform.GetChild(randomTileIndex).position, Quaternion.identity); 
    }
}
