using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPlace : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player1")
        {
            string sceneName = "WinScreen";
            SceneManager.LoadScene(sceneName);
        }
    }
}
