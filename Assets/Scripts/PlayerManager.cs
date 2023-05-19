using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int keyCount;

    KeyDestroy kd;
    public bool canBeAttacked = false;
    public int orbsDestroyed = 0;
    private void Awake()
    {

        kd = GetComponent<KeyDestroy>();

    }
    public void PickUpKey()
    {

        keyCount++;


    }

    public void UseKey()
    {
        keyCount--;

    }
}
