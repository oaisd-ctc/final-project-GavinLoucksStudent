using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class KeyDestroy : MonoBehaviour
{

    [SerializeField] UnityEvent collisionEnter;

    [SerializeField] AudioClip pickUpSFX;

    PlayerManager manager;


    private void Start()
    {
        manager = FindObjectOfType<PlayerManager>();
    }


    public void GrabKey()
    {

        manager.PickUpKey();
        AudioSource.PlayClipAtPoint(pickUpSFX, Camera.main.transform.position);
        collisionEnter?.Invoke();


    }



}
