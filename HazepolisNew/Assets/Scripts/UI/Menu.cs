using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //public RectTransform TitleMenuCanvas;
    public GameObject pauseMenu;
    public bool IsShow;

     void Start()
    {

        pauseMenu.SetActive(false);
        IsShow = false;
        Time.timeScale = (1);

        //標題畫面動畫
        //TitleAnimation();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsShow)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void StartGame()
    {
        Debug.Log("按下'開始'按鈕");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        //EditorApplication.isPlaying = false; 

        //這是因為Application.Quit是在遊戲Build後才會有作用，編輯狀態下是無效的
        // 如果想要在編輯狀態下關閉執行的話要使用到EditorApplication.isPlaying這個參數
    }

    public void BackIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void UIEable()
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
    }

    public void PauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        IsShow = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        IsShow = false;
        Time.timeScale = 1f;
    }

        //  public void TitleAnimation()
        //  {
        //      LeanTween.move(TitleMenuCanvas, new Vector3(48f, 0f, 0f), 1f).setDelay(.4f);
        //      LeanTween.alpha(TitleMenuCanvas, 2f, 5f ).setFrom(0f).setDelay(.5f).setEase(LeanTweenType.easeOutQuad);
        //  }

    }
