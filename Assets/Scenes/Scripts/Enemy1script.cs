using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1script : MonoBehaviour
{
    int side = 1;
    public float speed = 5;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(side*speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "SwitchSide")
        {
            side *= -1;
            if (side < 0) transform.localScale = Vector2.one;

            else if (side > 0) transform.localScale = new Vector2(-1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.name);

        if(coll.gameObject.name == "Player1")
        {
            GameObject GameManager = GameObject.Find("GameManager");
            GameManager gm = GameManager.GetComponent<GameManager>();

            switch (gameObject.name)
            {
                case "Enemy0":
                    Debug.Log("-5 Health");
                    gm.Health -= 5;
                    break;
                case "Enemy1":
                    gm.Health -= 15;
                    break;
            }
        }

        else if(coll.gameObject.tag == "SwitchSide")
        {
            side *= -1;
        }
    }
}
