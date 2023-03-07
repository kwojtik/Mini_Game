using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1script : MonoBehaviour
{
    //Dostêp do GM:
    GameManager gm;
    public static Player1script instance;

    Rigidbody2D rb;
    float xInput;
    public float speed;
    int DoubleJump = 2;

    public HealthBarScript healthbar;
    private void Awake()
    {
        if (Player1script.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        gm = GameManager.GetComponent<GameManager>();

        gm.CurrentMaxHealth = 100;
        gm.Health = 100;

        rb = GetComponent<Rigidbody2D>();

        //¯ycie
        healthbar.SetMaxHealth(gm.CurrentMaxHealth);
        healthbar.SetHealth(gm.Health);
    }

    void Update()
    {
        //Skakanie
        if (Input.GetKeyDown(KeyCode.Space) && (DoubleJump == 2 || DoubleJump == 1))
        {
            rb.AddForce(Vector2.up * 350);
            DoubleJump--;
        }
    }

    void FixedUpdate()
    {
        //Poruszanie sie
        xInput = Input.GetAxisRaw("Horizontal") * speed;
        Vector2 movement = new Vector2(xInput, 0);

        if (movement.x > 0) transform.localScale = Vector2.one;

        else if (movement.x < 0) transform.localScale = new Vector2(-1, 1);

        rb.AddForce(movement);
        healthbar.SetHealth(gm.Health);

        GameManager.instance.TryUpWeapon();
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        switch(trigger.gameObject.tag)
        {
            case "Deathzone":
                gm.Health = 0;
                break;
            case "Health":
                gm.Health = gm.CurrentMaxHealth;
                break;
            case "Portal":
                GameObject bossTrigger = GameObject.Find("Boss");
                Animator boss = bossTrigger.GetComponent<Animator>();
                boss.SetBool("Barrier", true);
                break;
            case "Boss":
                gm.Health -= 5;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag) 
        {
            case "Floor":
                DoubleJump = 2;
                break;
        }
    }
}
