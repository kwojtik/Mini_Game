using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite Checkpoint_A;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Player1")
        {
            GameManager.instance.SaveState();
            GetComponent<SpriteRenderer>().sprite = Checkpoint_A;
        }
    }
}
