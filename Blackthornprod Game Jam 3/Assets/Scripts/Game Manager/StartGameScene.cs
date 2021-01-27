using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScene : MonoBehaviour
{
    public Animator anim;
    public GameObject panelGO;
    
    public float timeB4deactiveSceneTransGO;
    bool deactivatedSceneTransGO;

    public PlayerController playerController;

    void Awake() {
        panelGO.SetActive(true);
    }
    void Start()
    {
        anim.SetTrigger("LoadedNewScene");
    }

    void Update()
    {
        if(timeB4deactiveSceneTransGO > 0)
        {
            timeB4deactiveSceneTransGO -= Time.deltaTime;
        }
        else
        {
            if(deactivatedSceneTransGO == false)
            {
                panelGO.SetActive(false);
                deactivatedSceneTransGO = true;
                playerController.canMove = true;
            }
        }
    }
}
