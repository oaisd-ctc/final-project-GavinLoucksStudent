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
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();


    }

    public void OpenDoor(GameObject obj)
    {
        if (!isOpen)
        {
            PlayerManager manager = obj.GetComponent<PlayerManager>();
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
