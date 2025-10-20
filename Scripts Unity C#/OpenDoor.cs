using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] Animator door;
    private bool isOpen = false;
    [SerializeField] GameObject key;
    [SerializeField] GameObject cylindre;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !isOpen)
        {
            door.Play("Door");
            isOpen = true;
            key.SetActive(false);
            cylindre.SetActive(false);
        }
        
    }


}
