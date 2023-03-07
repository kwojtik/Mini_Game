using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue //inf o dialogach
{
    public string name; //imiê npc
    [TextArea(3,10)] //w unity wielkoœæ pól na tekst
    public List<string> sentences = new List<string>();
}
