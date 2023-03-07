using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public GameObject Button; //do przycisku
    public bool PlayerInRange; //czy w zasiêgu npc

    void OnTriggerEnter2D(Collider2D other) //wchodz¹c w zasiêg
    {
        if (other.CompareTag("Ally")) //jeœli gracz w zasiêgu
        {
            PlayerInRange = true;
            Triggering();
        }
    }

    void OnTriggerExit2D(Collider2D other) //wychodz¹c
    {
        if (other.CompareTag("Ally")) //wychodz¹c
        {
            PlayerInRange = false;
            Button.SetActive(false); //ma znikn¹æ przycisk
        }
    }

    void Triggering() //funckja na wyœwietlanie przycisku
    {
        if (PlayerInRange)
        {
            if (Button.activeInHierarchy) //czy widaæ przycisk
            {
                Button.SetActive(false); //dezaktywacja
            } else
            {
                Button.SetActive(true); //aktywacja
            }
                
        }
    }
}
