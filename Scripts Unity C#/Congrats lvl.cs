using UnityEngine;

public class Congrats : MonoBehaviour
{
    [SerializeField] GameObject imagelvl;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            imagelvl.SetActive(true);
        }

            
    }


}