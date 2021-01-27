using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManagerPlayer : MonoBehaviour
{
    public PlayerController playerController;
    public TimeManager timeManager;
    public GameObject deathGO;
    public GameObject soundDeath;
    bool changedStuff;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Spikes" || col.gameObject.tag == "Arrow")
        {
            if(changedStuff == false && timeManager.isAlive == true)
            {
                playerController.canMove = false;
                deathGO.SetActive(true);
                timeManager.isAlive = false;
                Instantiate(soundDeath, this.gameObject.transform.position, Quaternion.identity);
                Time.timeScale = 0f;
                changedStuff = true;
            }
        }
    }
}
