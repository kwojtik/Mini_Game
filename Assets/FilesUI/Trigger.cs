using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public GameObject Button; //do przycisku
    public bool PlayerInRange; //czy w zasi�gu npc

    void OnTriggerEnter2D(Collider2D other) //wchodz�c w zasi�g
    {
        if (other.CompareTag("Ally")) //je�li gracz w zasi�gu
        {
            PlayerInRange = true;
            Triggering();
        }
    }

    void OnTriggerExit2D(Collider2D other) //wychodz�c
    {
        if (other.CompareTag("Ally")) //wychodz�c
        {
            PlayerInRange = false;
            Button.SetActive(false); //ma znikn�� przycisk
        }
    }

    void Triggering() //funckja na wy�wietlanie przycisku
    {
        if (PlayerInRange)
        {
            if (Button.activeInHierarchy) //czy wida� przycisk
            {
                Button.SetActive(false); //dezaktywacja
            } else
            {
                Button.SetActive(true); //aktywacja
            }
                
        }
    }
}
