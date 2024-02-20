using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatSpawner : MonoBehaviour
{
    public static ChatSpawner Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}