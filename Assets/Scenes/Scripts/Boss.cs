using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : Collidable
{
    Animator anim;
    Boss BC;
    public GameObject HealthbarBoss;
    public HealthBarScript healthbar;

    bool tmp = true;

    public int hitpoint = 1000;
    public int maxHitpoint = 1000;
    public float speed = 5;
    private CircleCollider2D circleCollider;

    protected float immuneTime = 0.5f;
    protected float lastImmune;
    protected float immuneTimeBoss = 0.25f;
    protected float lastImmuneBoss;

    protected override void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        BC = GetComponent<Boss>();
        anim = BC.GetComponent<Animator>();

        HealthbarBoss.SetActive(false);
        healthbar.SetMaxHealth(maxHitpoint);
        healthbar.SetHealth(hitpoint);
    }

    protected override void Update()
    {
        circleCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) continue;

            OnCollide(hits[i]);

            hits[i] = null;
        }

        if (anim.GetBool("Barrier") == true)
        {
            anim.SetTrigger("Help");
            HealthbarBoss.SetActive(true);

            switch (anim.GetInteger("BossMovement"))
            {
                case 0:
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle0"))
                    {
                        anim.SetInteger("BossMovement", 1);
                        if (tmp)
                        {
                            gameObject.GetComponent<FireBullet>().Summon(90f, 270f);
                            tmp = false;
                        }
                    }
                    break;

                case 1:
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("EightMovement"))
                    {
                        anim.SetInteger("BossMovement", 2);
                        gameObject.GetComponent<FireBullet>().StopSummon();
                        tmp = true;
                    }
                    break;

                case 2:
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) anim.SetInteger("BossMovement", 3);
                    break;

                case 3:
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("CircleMovement"))
                    {
                        anim.SetInteger("BossMovement", 4);
                        if (tmp)
                        {
                            gameObject.GetComponent<FireBullet>().Summon(0f, 360f);
                            tmp = false;
                        }
                    }
                    break;

                case 4:
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle2"))
                    {
                        anim.SetInteger("BossMovement", 1);
                        gameObject.GetComponent<FireBullet>().StopSummon();
                        tmp = true;
                    }
                    break;
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            SceneManager.LoadScene("WinPlace");
        }
    }

    void FixedUpdate()
    {
        healthbar.SetHealth(hitpoint);
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.gameObject.name == "Player1")
        {
            GameObject GameManager = GameObject.Find("GameManager");
            GameManager gm = GameManager.GetComponent<GameManager>();

            if (Time.time - lastImmune > immuneTime)
            {
                lastImmune = Time.time;
                gm.Health -= 10;
            }
        }
        if (coll.gameObject.name == "Weapon_0")
        {
            if (Time.time - lastImmuneBoss > immuneTimeBoss)
            {
                lastImmuneBoss = Time.time;
                hitpoint -= 25;

                if(hitpoint <= 0)
                {
                    Death();
                }
            }
        }
    }

    void Death()
    {
        HealthbarBoss.SetActive(false);
        anim.SetTrigger("IsDead");
        anim.SetBool("Barrier", false);
    }
}
