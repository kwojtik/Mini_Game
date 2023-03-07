using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; //u¿ywamy klasy Dialogue
    public GameObject DialogueBox;
    public bool HaveTalked = false;

    public void TriggerDialogue()
    {

        if (DialogueBox.activeInHierarchy) //czy widaæ pole na tekst
        {
            DialogueBox.SetActive(false); //Zamykanie okna
        }
        else
        {
            DialogueBox.SetActive(true); //Pokazywanie okna
        }

        dialogue.name = "Happy";

        if (HaveTalked)
        {
            dialogue.sentences.Clear();

            dialogue.sentences.Add("Stop talking to me, I told you everything.");
        }
        else
        {
            dialogue.sentences.Add("Oh, it is nice to see someone normal around here!");
            dialogue.sentences.Add("Why the long face? Did something happen?");
            dialogue.sentences.Add("Ok I didn't really care anyway...");
            dialogue.sentences.Add("Did you know that when you get enough money your sword upgrades? Really cool.");

            HaveTalked = true;
        }
        

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
