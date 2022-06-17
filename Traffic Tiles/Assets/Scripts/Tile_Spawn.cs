using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Spawn : MonoBehaviour
{
    public GameObject[] tile;

    public List<GameObject> clones1 = new List<GameObject>(); //list of tiles in first column.
    public List<GameObject> clones2 = new List<GameObject>(); //list of tiles in second column.

    public float row = 0; //z value of a given row of tiles. Starts at 0.

    public int count = 0; //total number of spawned tiles. Starts at 0.
    public int increase = 8; //z value increases by x amount per row of tiles.
    public int limit = 4; //limits number of spawned tiles to x amount per column.
    public int limitGreen = 7; //green tiles cannot spawn within x tiles of each other.
    public int number; //random number determines tile colour (0 = red, 1 = amber, 2 = green).


    void Awake()
    {
        Spawn();
    }

    //calls functions to spawn all tiles in columns 1 and 2.
    public void Spawn()
    {
        Spawn1();
        Spawn2();
    }

    //spawns tiles in the first column until limit is reached, limiting the number of green tile spawns.
    public void Spawn1()
    {
        for (int i = 0; i < limit; i++)
        {
            Vector3 spawn1 = new Vector3(0, 0, i * increase + row);
            number = Random.Range(0, 3);

            if (number == 0)
            {
                clones1.Add(Instantiate(tile[0], spawn1, Quaternion.identity));
                limitGreen++;
            }

            if (number == 1)
            {
                clones1.Add(Instantiate(tile[1], spawn1, Quaternion.identity));
                limitGreen++;
            }

            if (number == 2)
            {
                if (limitGreen >= 7)
                {
                    clones1.Add(Instantiate(tile[2], spawn1, Quaternion.identity));
                    limitGreen = 0;
                }

                else
                {
                    number = Random.Range(0, 2);

                    if (number == 0)
                    {
                        clones1.Add(Instantiate(tile[0], spawn1, Quaternion.identity));
                        limitGreen++;
                    }

                    if (number == 1)
                    {
                        clones1.Add(Instantiate(tile[1], spawn1, Quaternion.identity));
                        limitGreen++;
                    }
                }
            }
            
            count++;
        }
    }

    //spawns tiles in the second column until limit is reached, limiting the number of green tile spawns.
    public void Spawn2()
    {
        for (int i = 0; i < limit; i++)
        {
            Vector3 spawn2 = new Vector3(6, 0, i * increase + row);
            number = Random.Range(0, 3);

            if (number == 0)
            {
                clones2.Add(Instantiate(tile[0], spawn2, Quaternion.identity));
                limitGreen++;
            }

            if (number == 1)
            {
                clones2.Add(Instantiate(tile[1], spawn2, Quaternion.identity));
                limitGreen++;
            }

            if (number == 2)
            {
                if (limitGreen >= 7)
                {
                    clones2.Add(Instantiate(tile[2], spawn2, Quaternion.identity));
                    limitGreen = 0;
                }

                else
                {
                    number = Random.Range(0, 2);

                    if (number == 0)
                    {
                        clones2.Add(Instantiate(tile[0], spawn2, Quaternion.identity));
                        limitGreen++;
                    }

                    if (number == 1)
                    {
                        clones2.Add(Instantiate(tile[1], spawn2, Quaternion.identity));
                        limitGreen++;
                    }
                }
            }

            count++;
        }
    }
}
