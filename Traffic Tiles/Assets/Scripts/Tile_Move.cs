using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Move : MonoBehaviour
{
    public List<GameObject> clones1 = new List<GameObject>(); //list of active tiles in first column.
    public List<GameObject> clones2 = new List<GameObject>(); //list of active tiles in second column.

    //identifies each tile in the bottom row.
    public bool red1 = false;
    public bool amber1 = false;
    public bool green1 = false;

    public bool red2 = false;
    public bool amber2 = false;
    public bool green2 = false;
    
    
    /*[SerializeField] private Animator tile;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Green")
        {
            //tile.Play();
        }
    }*/

    void Start()
    {
        clones1 = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().clones1;
        clones2 = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().clones2;
    }
    
    public void Move()
    {
        green1 = false;
        green2 = false;
    }
}
