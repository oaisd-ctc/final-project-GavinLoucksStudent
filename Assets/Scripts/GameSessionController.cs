using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessionController : MonoBehaviour
{

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSessionController>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    public void ProcessPlayerDeath()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
