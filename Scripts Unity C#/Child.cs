using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    [SerializeField] GameObject Congratulation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Congratulation.SetActive(true);
        }
    }
}
