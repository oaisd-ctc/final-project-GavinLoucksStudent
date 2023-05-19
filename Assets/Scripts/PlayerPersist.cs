using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersist : MonoBehaviour
{

    public static PlayerPersist playerInstance;

    void Start()
    {
        if (playerInstance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            playerInstance = this;
            DontDestroyOnLoad(playerInstance.gameObject);
        }
    }
}
