using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    int damage = 20;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().ChangeHealth(-damage);
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().ChangeHealth(-damage);
        }

    }
}
