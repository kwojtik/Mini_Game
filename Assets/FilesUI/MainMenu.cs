using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [Header("Levels to load")]
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGame = null; //gdy nie ma zapisu to by to okno wychodzi³o

    public void PlayGame ()
    {
        if (GameObject.Find("GameManager"))
        {
            GameObject gm;
            gm = GameObject.Find("GameManager");

            PlayerPrefs.DeleteAll();
            gm.GetComponent<GameManager>().NewGame();
        }
        else SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void LoadGame()
    {
        if (GameObject.Find("GameManager"))
        {
            SceneManager.LoadScene("SampleScene");
        } 
        else
        {
            noSavedGame.SetActive(true);
        }
    }
}
