using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public GameObject[] player;
    public GameObject[] tile;

    public Transform[] spawn;

    public List<GameObject> clones1 = new List<GameObject>(); //list of tiles in first column.
    public List<GameObject> clones2 = new List<GameObject>(); //list of tiles in second column.

    //identifies each tile in the active row.
    public bool red1 = false;
    public bool amber1 = false;
    public bool green1 = false;

    public bool red2 = false;
    public bool amber2 = false;
    public bool green2 = false;

    public float playerZ = 0; //player's z axis.

    public int increase; //z value increases by x amount per row of tiles.
    public int maximum = 4; //maximum number of elements in a given list.


    void Start()
    {
        clones1 = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().clones1;
        clones2 = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().clones2;
        increase = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().increase;
    }

    //identifies each tile in the active row and sets bool values accordingly.
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

        if (Input.GetKeyDown("w"))
        {
            CycleForward();
        }

        if (Input.GetKeyDown("s"))
        {
            CycleBackward();
        }
    }

    //moves the player up to the next row of tiles and spawns a new tile at the top of each column.
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
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().row = transform.position.z + 24;
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().Spawn();
    }

    void TileMove()
    {
        //GameObject.FindObjectWithTag("Move").GetComponent<Tile_Move>().Move();
    }

    //cycles tile in column 1 forward one colour (red --> amber --> green --> red).
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

    //cycles tile in column 2 forward one colour (red --> amber --> green --> red).
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

    //cycles tiles in columns 1 and 2 forward one colour (red --> amber --> green --> red).
    void CycleForward()
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

    //cycles tiles in columns 1 and 2 backward one colour (red --> green --> amber --> red).
    void CycleBackward()
    {
        if (red1)
        {
            GameObject.Destroy(clones1[0]);
            clones1.Add(clones1[0] = Instantiate(tile[2], spawn[0].position, Quaternion.identity));
        }

        if (amber1)
        {
            GameObject.Destroy(clones1[0]);
            clones1.Add(clones1[0] = Instantiate(tile[0], spawn[0].position, Quaternion.identity));
        }

        if (green1)
        {
            GameObject.Destroy(clones1[0]);
            clones1.Add(clones1[0] = Instantiate(tile[1], spawn[0].position, Quaternion.identity));
        }

        if (red2)
        {
            GameObject.Destroy(clones2[0]);
            clones2.Add(clones2[0] = Instantiate(tile[2], spawn[1].position, Quaternion.identity));
        }

        if (amber2)
        {
            GameObject.Destroy(clones2[0]);
            clones2.Add(clones2[0] = Instantiate(tile[0], spawn[1].position, Quaternion.identity));
        }

        if (green2)
        {
            GameObject.Destroy(clones2[0]);
            clones2.Add(clones2[0] = Instantiate(tile[1], spawn[1].position, Quaternion.identity));
        }

        CleanList();
    }

    //prevents lists from exceeding the maximum number of elements.
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
