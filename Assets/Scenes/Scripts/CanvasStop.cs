using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStop : MonoBehaviour
{
    public static CanvasStop instance;

    private void Awake()
    {
        if (CanvasStop.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
