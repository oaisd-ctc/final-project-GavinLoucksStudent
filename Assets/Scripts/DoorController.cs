using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public BoxCollider2D bc;

    [SerializeField] AudioClip openSFX;

    public bool isOpen;

    public Animator animator;
    PlayerManager manager;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        manager = FindObjectOfType<PlayerManager>();

    }

    public void OpenDoor()
    {
        if (!isOpen)
        {

            if (manager)
            {
                if (manager.keyCount > 0)
                {
                    isOpen = true;
                    manager.UseKey();

                    animator.SetBool("doorOpen", isOpen);
                    AudioSource.PlayClipAtPoint(openSFX, Camera.main.transform.position);
                    bc.enabled = !bc.enabled;

                }
            }
        }
    }




}
