using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Destroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Green")
        {
            Destroy(other.gameObject);
        }
    }
}
