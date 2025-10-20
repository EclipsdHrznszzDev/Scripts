using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            FindObjectOfType< PlayerMove>().ocean();
            
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerMove>().surface();
        }

    }
}
