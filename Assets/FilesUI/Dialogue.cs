using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue //inf o dialogach
{
    public string name; //imi� npc
    [TextArea(3,10)] //w unity wielko�� p�l na tekst
    public List<string> sentences = new List<string>();
}
