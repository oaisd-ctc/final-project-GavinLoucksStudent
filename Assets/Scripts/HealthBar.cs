using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    GameSessionController gsc;


    private void Start()
    {
        gsc = FindObjectOfType<GameSessionController>();
    }



}
