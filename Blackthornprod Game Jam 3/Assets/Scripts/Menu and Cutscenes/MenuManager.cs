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

    public void YouTubeLink()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCBgA6tSAxLkdLJVAILqZLuQ");
    }

    public void TwitterLink()
    {
        Application.OpenURL("https://twitter.com/galse22");
    }

    void ActualLoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
