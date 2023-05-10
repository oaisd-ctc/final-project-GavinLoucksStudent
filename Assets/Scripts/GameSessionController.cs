using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameSessionController : MonoBehaviour
{

    [SerializeField] Slider slider;

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
