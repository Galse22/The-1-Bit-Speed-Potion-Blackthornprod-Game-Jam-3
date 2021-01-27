using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public StartGameScene startGameSceneScript;
    public RestartScene restartSceneScript;
    public Slider slider;
    public float timeToCompleteLvl;
    public GameObject timeIsUpGO;
    public PlayerController playerController;

    bool calledFuncRestartSceneScript;
    [HideInInspector]public bool isAlive = true;

    private void Awake() {
        slider.maxValue = timeToCompleteLvl;
        slider.value = timeToCompleteLvl;
    }

    void Update()
    {
        if(startGameSceneScript.timeB4deactiveSceneTransGO <= 0 && isAlive)
        {
            if(timeToCompleteLvl >= 0)
            {
                timeToCompleteLvl -= Time.deltaTime;
                slider.value = timeToCompleteLvl;
            }
            else
            {
                if(calledFuncRestartSceneScript == false)
                {
                    calledFuncRestartSceneScript = true;
                    isAlive = false;
                    Time.timeScale = 0f;
                    playerController.canMove = false;
                    timeIsUpGO.SetActive(true);
                }
            }
        }
    }
}
