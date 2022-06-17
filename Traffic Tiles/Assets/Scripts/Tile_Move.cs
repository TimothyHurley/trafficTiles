using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Move : MonoBehaviour
{
    public Animator tileAnim;
    public string tileMove = "Tile_Move";
    
    public void Move()
    {
        tileAnim.Play(tileMove);
    }
}
