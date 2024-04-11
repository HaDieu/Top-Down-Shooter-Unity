using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_InGame : MonoBehaviour
{
    public GameObject pauseGame;
    
    public CanvasGroup settingCanvasGroup;

    private void Start()
    {
        Time.timeScale = 1f;
        pauseGame.SetActive(false);
        

        settingCanvasGroup.alpha = 0f;
        settingCanvasGroup.interactable = false;
        settingCanvasGroup.blocksRaycasts = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        pauseGame.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void ContinueGame()
    {
        pauseGame.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void SettingMusic()
    {
        settingCanvasGroup.alpha = 1f;
        settingCanvasGroup.interactable = true;
        settingCanvasGroup.blocksRaycasts = true;
    }

    public void ExitSettingMusic()
    {
        settingCanvasGroup.alpha = 0f;
        settingCanvasGroup.interactable = false;
        settingCanvasGroup.blocksRaycasts = false;
        Time .timeScale = 1.0f;
    }

}
