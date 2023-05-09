using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int keyCount;
    KeyDestroy kd;

    private void Start()
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
