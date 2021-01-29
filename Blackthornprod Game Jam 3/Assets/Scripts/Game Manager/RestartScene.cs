using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public float timeBtwRestartScene;
    public float timeAfterRKey;
    public GameObject sceneTransGO;
    public Animator panelAnim;
    public bool windowsVer;
    void Update()
    {
        if(timeBtwRestartScene > 0)
        {
            timeBtwRestartScene -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.R) && timeBtwRestartScene <= 0){
            StartCoroutine("RestartSceneCoroutine");
        }

        if(windowsVer == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void PublicFuncRestart()
    {
        StartCoroutine("RestartSceneCoroutine");
    }

    IEnumerator RestartSceneCoroutine()
    {
        Time.timeScale = 1f;
        sceneTransGO.SetActive(true);
        panelAnim.SetTrigger("GoingToNewScene");
        yield return new WaitForSeconds(timeAfterRKey);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
