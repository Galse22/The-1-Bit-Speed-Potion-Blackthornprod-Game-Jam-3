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

    bool calledFuncRestartSceneScript;

    void Update()
    {
        if(startGameSceneScript.timeB4deactiveSceneTransGO <= 0)
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
                    restartSceneScript.PublicFuncRestart();
                }
            }
        }
    }
}
