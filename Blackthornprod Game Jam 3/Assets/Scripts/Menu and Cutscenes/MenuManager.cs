using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        ActualLoadScene();
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

    public void QuitGame()
    {
        Application.Quit();
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
