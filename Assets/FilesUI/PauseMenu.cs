using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;

    public GameObject PauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) //esc - przycisk by zapauzowaæ
        {
            if(IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    void Pause()
    {
        PauseMenuUI.SetActive(true); //aktywowanie ekranu pauzy
        Time.timeScale = 0f; //by zatrzyma³ siê czas
        IsGamePaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false); //dezaktywowanie ekranu pauzy
        Time.timeScale = 1f; //normalny czas
        IsGamePaused = false;
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); 
    }
}
