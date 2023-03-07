using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        PlayerPrefs.DeleteAll();

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;

    // Referencje
    public Player1script player;
    public Weapon weapon;

    // Wyniki
    public int MoneyScore;
    public int Health;
    public int CurrentMaxHealth;

    //pozycja
    public float x;
    public float y;

    //Ulepszenie broni
    public bool TryUpWeapon()
    {
        //Czy da siê ulepszyæ
        if (weapon.weaponLevel >= 1) return false;

        if(MoneyScore >= 7)
        {
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }

    //œmieræ
    void Update()
    {   
        if (Health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Zapis
    public void SaveState()
    {
        string saveS = " ";

        //zapisanie pozycji gracza
        GameObject player = GameObject.Find("Player1");
        Transform playerposition = player.GetComponent<Transform>();
        x = playerposition.position.x;
        y = playerposition.position.y; 

        saveS += MoneyScore.ToString() + "|";
        saveS += Health.ToString() + "|";
        saveS += CurrentMaxHealth.ToString() + "|";
        saveS += x.ToString() + "|";
        saveS += y.ToString() + "|";
        saveS += weapon.weaponLevel.ToString() + "|";

        PlayerPrefs.SetString("SaveState", saveS);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {

        if (!PlayerPrefs.HasKey("SaveState")) return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        GameObject player = GameObject.Find("Player1");
        Transform playerposition = player.GetComponent<Transform>();

        //Za³adowanie wyniku
        MoneyScore = int.Parse(data[0]);
        Health = int.Parse(data[1]);
        CurrentMaxHealth = int.Parse(data[2]);
        x = float.Parse(data[3]);
        y = float.Parse(data[4]);
        playerposition.position = new Vector2(x, y);
        weapon.weaponLevel= int.Parse(data[5]);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");

        GameObject player = GameObject.Find("Player1");
        Transform playerposition = player.GetComponent<Transform>();

        playerposition.position = new Vector2(-0.92f, 0.42f);
    }
}
