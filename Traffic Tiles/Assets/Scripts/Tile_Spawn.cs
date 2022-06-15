using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Spawn : MonoBehaviour
{
    public GameObject[] tile;

    public List<GameObject> clones1 = new List<GameObject>(); //list of active tiles in first column.
    public List<GameObject> clones2 = new List<GameObject>(); //list of active tiles in second column.

    [HideInInspector] public float start = 0; //z value of first tile row.

    [HideInInspector] public int count = 0; //total number of spawned tiles. Starts at 0.
    [HideInInspector] public int increase = 8; //distance between each row of tiles.
    [HideInInspector] public int limit = 5; //limits number of spawned tiles per column.
    [HideInInspector] public int limitGreen = 7; //reduces number of green spawned tiles. X is the minimum number of non-green spawns between each green tile.
    [HideInInspector] public int max = 5; //identifies when the count must stop.
    [HideInInspector] public int number; //random number determines tile colour (0 = red, 1 = amber, 2 = green).


    void Awake()
    {
        Spawn();
    }

    //spawns tiles in two columns until max has been reached.
    public void Spawn()
    {
        Spawn1();
        Spawn2();

        Debug.Log(count);

        if (count < max)
        {
            Spawn();
        }
    }

    //spawns a tile in the first column, limiting the number of green tile spawns.
    public void Spawn1()
    {
        for (int i = 0; i < limit * max; i += increase)
        {
            Vector3 spawn1 = new Vector3(0, 0, i + start);
            number = Random.Range(0, 3);

            if (number == 0)
            {
                clones1.Add(Instantiate(tile[0], spawn1, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }

            if (number == 1)
            {
                clones1.Add(Instantiate(tile[1], spawn1, Quaternion.identity));
                limitGreen = limitGreen + 1;
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
                        limitGreen = limitGreen + 1;
                    }

                    if (number == 1)
                    {
                        clones1.Add(Instantiate(tile[1], spawn1, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                }
            }
            
            count = count + 1;
        }
    }

    //spawns a tile in the second column, limiting the number of green tile spawns.
    public void Spawn2()
    {
        for (int i = 0; i < limit * max; i += increase)
        {
            Vector3 spawn2 = new Vector3(6, 0, i + start);
            number = Random.Range(0, 3);

            if (number == 0)
            {
                clones2.Add(Instantiate(tile[0], spawn2, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }

            if (number == 1)
            {
                clones2.Add(Instantiate(tile[1], spawn2, Quaternion.identity));
                limitGreen = limitGreen + 1;
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
                        limitGreen = limitGreen + 1;
                    }

                    if (number == 1)
                    {
                        clones2.Add(Instantiate(tile[1], spawn2, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                }
            }

            count = count + 1;
        }
    }
}
