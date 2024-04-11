using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_OutGame : MonoBehaviour
{
    public GameObject guideGame;
    // Start is called before the first frame update
    void Start()
    {
        guideGame.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OutGame()
    {
        Application.Quit();
    }

    public void GuideGame()
    {
        guideGame.SetActive(true);
    }

    public void ExitGuideGame()
    {
        guideGame.SetActive(false);
    }


}
