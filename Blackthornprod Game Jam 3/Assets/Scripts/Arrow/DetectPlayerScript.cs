using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerScript : MonoBehaviour
{
    public GameObject arrow;
    public Transform placeToSpawn;
    bool hasSpawnedArrow;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && hasSpawnedArrow == false)
        {
            hasSpawnedArrow = true;
            Instantiate(arrow, placeToSpawn.position, Quaternion.identity);
        }
    }
}
