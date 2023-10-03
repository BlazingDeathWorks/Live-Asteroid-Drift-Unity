using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton : MonoBehaviour
{
    public static PersistentSingleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
