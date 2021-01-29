using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManagerPlayer : MonoBehaviour
{
    [Header("Player")]
    public PlayerController playerController;
    public TimeManager timeManager;
    public Animator playerAnim;

    [Header("Death")]
    public GameObject deathGO;
    public GameObject soundDeath;
    bool changedStuff;
    bool shouldDie = true;

    [Header("Win")]
    public GameObject sceneTransGO;
    public Animator panelAnim;
    public int sceneToGoInt;
    public float timeNextScene;

    [Header ("Screenshake")]
    public float screenshakeTime;
    public float screenshakeIntesity;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Spikes" || col.gameObject.tag == "Arrow" && shouldDie == true)
        {
            if(changedStuff == false && timeManager.isAlive == true)
            {
                CinemachineShake.Instance.ShakeCamera(screenshakeIntesity, screenshakeTime);
                playerController.canMove = false;
                playerAnim.SetTrigger("Default");
                deathGO.SetActive(true);
                timeManager.isAlive = false;
                Instantiate(soundDeath, this.gameObject.transform.position, Quaternion.identity);
                changedStuff = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Spikes" || other.gameObject.tag == "Arrow" && shouldDie == true)
        {
            if(changedStuff == false && timeManager.isAlive == true)
            {
                CinemachineShake.Instance.ShakeCamera(screenshakeIntesity, screenshakeTime);
                playerController.canMove = false;
                playerAnim.SetTrigger("Default");
                deathGO.SetActive(true);
                timeManager.isAlive = false;
                Instantiate(soundDeath, this.gameObject.transform.position, Quaternion.identity);
                changedStuff = true;
            }
        }
        else if(other.gameObject.tag == "Potion" || other.gameObject.tag == "Wizard")
        {
            shouldDie = false;
            timeManager.isAlive = false;
            Invoke("NextScene", timeNextScene);
            sceneTransGO.SetActive(true);
            panelAnim.SetTrigger("GoingToNewScene");
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(sceneToGoInt);
    }
}
