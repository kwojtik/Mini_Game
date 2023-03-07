using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Collectible
{
    protected override void OnCollect()
    {
        //Dost�p do zmiennej Money w GameManager
        GameObject GameManager = GameObject.Find("GameManager");
        GameManager money = GameManager.GetComponent<GameManager>();

        //Zebranie pieni��ka i dodanie go do wyniku
        if (!collected)
        {
            collected = true;
            Destroy(gameObject);

            money.MoneyScore++;
        }
    }
}
