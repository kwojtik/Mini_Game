using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Collidable
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float speed = 5;

    protected float immuneTime = 0.5f;
    protected float lastImmune;

    int side = 1;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.dmgAmount;
            Vector3 difference = (transform.position - dmg.origin).normalized;
            Vector3 force = difference * dmg.knockback;
            rb.AddForce(force, ForceMode2D.Impulse);

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }

    protected override void Update()
    {
        base.Update();

        rb.velocity = new Vector2(side * speed, 0);
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

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "SwitchSide")
        {
            side *= -1;
            if (side < 0) transform.localScale = Vector2.one;

            else if (side > 0) transform.localScale = new Vector2(-1, 1);
        }
        if (coll.gameObject.name == "Player1")
        {
            GameObject GameManager = GameObject.Find("GameManager");
            GameManager gm = GameManager.GetComponent<GameManager>();

            if(Time.time - lastImmune > immuneTime)
            {
                lastImmune = Time.time;
                switch (sr.sprite.name)
                {
                    case "Enemy0Sprite":
                        gm.Health -= 5;
                        break;
                    case "Enemy1Sprite":
                        gm.Health -= 15;
                        break;
                }
            }

        }
    }
}
