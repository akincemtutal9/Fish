using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    private static PlayerInstance instance = null;

    public static PlayerInstance Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("Player").AddComponent<PlayerInstance>();
            }

            return instance;
        }
    }
}
