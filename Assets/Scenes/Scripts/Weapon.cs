using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage struct
    public int[] damagePoint = {5, 15};
    public float[] kback = {0, 3.0f};

    //upgrade
    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;

    //Swing
    private float cooldown = 0.33f;
    private float lastSwing;
    private Animator SwordAnim;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        SwordAnim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update(); 

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
        SetWeaponLevel(weaponLevel);
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Ally")
            return;
        
        if(coll.tag == "Enemy")
        {
            Damage dmg = new Damage
            {
                dmgAmount = damagePoint[weaponLevel],
                origin = transform.position,
                knockback = kback[weaponLevel]
            };
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing()
    {
        SwordAnim.SetTrigger("Swing");
    }

    public void UpgradeWeapon()
    {
        if(spriteRenderer != null)
        {
            weaponLevel++;
            spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
        }
 
    }

    public void SetWeaponLevel(int lvl)
    {
        if(spriteRenderer != null)
        {
            weaponLevel = lvl;
            spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
        }
    }
}
