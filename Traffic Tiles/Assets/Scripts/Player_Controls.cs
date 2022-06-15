using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public GameObject[] player;
    public GameObject[] tile;

    public Transform[] spawn;

    public List<GameObject> clones1 = new List<GameObject>(); //list of active tiles in first column.
    public List<GameObject> clones2 = new List<GameObject>(); //list of active tiles in second column.

    //identifies each tile in the bottom row.
    public bool red1 = false;
    public bool amber1 = false;
    public bool green1 = false;

    public bool red2 = false;
    public bool amber2 = false;
    public bool green2 = false;

    public float playerZ = 0; //player's z axis.

    [HideInInspector] public int increase; //distance between each row of tiles.
    [HideInInspector] public int maximum = 5; //identifies when the count must stop.


    void Start()
    {
        clones1 = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().clones1;
        clones2 = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().clones2;
        increase = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().increase;
    }

    void OnTriggerEnter(Collider other)
    {
        if (player[0].tag == "Column_1")
        {
            if (clones1[0].tag == "Red")
            {
                red1 = true;
                amber1 = false;
                green1 = false;
            }

            if (clones1[0].tag == "Amber")
            {
                red1 = false;
                amber1 = true;
                green1 = false;
            }

            if (clones1[0].tag == "Green")
            {
                red1 = false;
                amber1 = false;
                green1 = true;
            }
        }

        if (player[1].tag == "Column_2")
        {
            if (clones2[0].tag == "Red")
            {
                red2 = true;
                amber2 = false;
                green2 = false;
            }

            if (clones2[0].tag == "Amber")
            {
                red2 = false;
                amber2 = true;
                green2 = false;
            }

            if (clones2[0].tag == "Green")
            {
                red2 = false;
                amber2 = false;
                green2 = true;
            }
        }
    }

    void Update()
    {
        if (green1 && green2)
        {
            PlayerMove();
            TileMove();
        }

        if (Input.GetKeyDown("a"))
        {
            Cycle1();
        }

        if (Input.GetKeyDown("d"))
        {
            Cycle2();
        }
    }

    void PlayerMove()
    {
        green1 = false;
        green2 = false;

        for (float i = transform.position.z; i < playerZ + increase; i += increase)
        {
            transform.position = transform.position + new Vector3(0, 0, increase);
        }

        playerZ = transform.position.z;

        clones1.RemoveAt(0);
        clones2.RemoveAt(0);

        GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().count = 0;
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().limit = 1;
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().max = 2;
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().start = transform.position.z + 32;
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().Spawn();
    }

    void TileMove()
    {
        //GameObject.FindObjectWithTag("Move").GetComponent<Tile_Move>().Move();
    }

    void Cycle1()
    {
        if (red1)
        {
            GameObject.Destroy(clones1[0]);
            clones1.Add(clones1[0] = Instantiate(tile[1], spawn[0].position, Quaternion.identity));
        }
        
        if (amber1)
        {
            GameObject.Destroy(clones1[0]);
            clones1.Add(clones1[0] = Instantiate(tile[2], spawn[0].position, Quaternion.identity));
        }

        if (green1)
        {
            GameObject.Destroy(clones1[0]);
            clones1.Add(clones1[0] = Instantiate(tile[0], spawn[0].position, Quaternion.identity));
        }

        CleanList();
    }

    void Cycle2()
    {
        if (red2)
        {
            GameObject.Destroy(clones2[0]);
            clones2.Add(clones2[0] = Instantiate(tile[1], spawn[1].position, Quaternion.identity));
        }

        if (amber2)
        {
            GameObject.Destroy(clones2[0]);
            clones2.Add(clones2[0] = Instantiate(tile[2], spawn[1].position, Quaternion.identity));
        }

        if (green2)
        {
            GameObject.Destroy(clones2[0]);
            clones2.Add(clones2[0] = Instantiate(tile[0], spawn[1].position, Quaternion.identity));
        }

        CleanList();
    }

    void CleanList()
    {
        if (clones1.Count > maximum)
        {
            clones1.RemoveAt(maximum);
            CleanList();
        }

        if (clones2.Count > maximum)
        {
            clones2.RemoveAt(maximum);
            CleanList();
        }
    }
}
