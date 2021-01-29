using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public Sprite[] imageArray;
    public Image baseImage;
    public int sceneNumber;
    public int amountsButton;

    public GameObject sceneTransGO;
    public Animator panelAnim;
    public float loadTime;

    void Awake()
    {
        sceneTransGO.SetActive(true);
        panelAnim.SetTrigger("LoadedNewScene");
    }

    void Start()
    {
        Invoke("DeactivateGO", 1.1f);
    }


    public void ChangeImage()
    {
        amountsButton++;
        if(amountsButton < imageArray.Length)
        {
            baseImage.overrideSprite = imageArray[amountsButton];
        }
        else
        {
            Invoke("ActualLoadScene", loadTime);
            sceneTransGO.SetActive(true);
            panelAnim.SetTrigger("GoingToNewScene");
        }
    }

    void ActualLoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    void DeactivateGO()
    {
        sceneTransGO.SetActive(false);
    }
}
