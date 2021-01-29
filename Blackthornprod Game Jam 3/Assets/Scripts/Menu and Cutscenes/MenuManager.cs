using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject sceneTransGO;
    public Animator panelAnim;
    public float loadTime;
    public void LoadGame()
    {
        sceneTransGO.SetActive(true);
        panelAnim.SetTrigger("GoingToNewScene");
        Invoke("ActualLoadScene", loadTime);
    }

    void ActualLoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void BugsScene()
    {
        SceneManager.LoadScene(7);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void YTLink()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCBgA6tSAxLkdLJVAILqZLuQ");
    }

    public void TwitterLink()
    {
        Application.OpenURL("https://twitter.com/galse22");
    }
}
