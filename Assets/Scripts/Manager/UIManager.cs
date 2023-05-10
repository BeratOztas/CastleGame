using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using Player;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private PlayerManagement playerManagement;

    [Header("UIS")]
    [SerializeField] private GameObject tapToPlayUI;
    [SerializeField] private GameObject nextLvlUI;
    [SerializeField] private GameObject restartLvlUI;
    [SerializeField] private GameObject pauseLvlUI;

    [Header("Buttons")]
    [SerializeField] private GameObject nextLevelButton;


    [Header("Texts")]
    [SerializeField] private TMP_Text currentLvl;

    public bool isPaused;

    
    private void Start()
    {
        isPaused = true;
        LevelText();
    }
    public void PlayResButton()
    {
        if (tapToPlayUI.activeSelf)
        {
            tapToPlayUI.SetActive(false);
            isPaused = false;
            playerManagement.SetCanWalk(true);
        }
        if (nextLvlUI.activeSelf)
        {
            nextLvlUI.SetActive(false);
            isPaused = false;
            // ResMultiplierButton();

            LevelManager.Instance.LevelUp();
            LevelText();
            playerManagement.CharacterReset();
            LevelManager.Instance.GenerateCurrentLevel();
        }
        if (restartLvlUI.activeSelf)
        {
            restartLvlUI.SetActive(false);
            isPaused = false;
            Debug.Log("REstarted");
            playerManagement.CharacterReset();
            LevelManager.Instance.GenerateCurrentLevel();
        }
        if (pauseLvlUI.activeSelf)
        {
            pauseLvlUI.SetActive(false);
            isPaused = false;
            ResumeGame();
        }


    }//PlayResButton
    

    public void NextLvlUI()
    {
        if (!isPaused)
        {
            tapToPlayUI.SetActive(false);
            nextLvlUI.SetActive(true);
            isPaused = true;
            NextLvl();
            Debug.Log("Finished Level");
        }
        
    }//NextLvlUI

    public void RestartButtonUI()
    {
        if (!isPaused)
        {
            restartLvlUI.SetActive(true);

            isPaused = true;
        }
    }//restartButton

    public void PauseButtonUI()
    {
        if (!isPaused)
        {
            // pausedText.SetActive(true);
            pauseLvlUI.SetActive(true);
            isPaused = true;
            PauseGame();
            //stop the game

        }
    }//pauseButton
    public void TapToPlay()
    {
        if (!isPaused)
        {
            tapToPlayUI.SetActive(true);
            isPaused = true;
        }
    }

    


    public void LevelText()
    {
        int LevelInt = LevelManager.Instance.GetGlobalLevelIndex() + 1;
        currentLvl.text = "Level " + LevelInt;
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    void NextLvl()
    {
        nextLevelButton.SetActive(true);
    }
    public void UIQuitGame()
    {
        Application.Quit();
    }

}
