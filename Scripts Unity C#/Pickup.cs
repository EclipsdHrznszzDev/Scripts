using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject MainPlayer;
    [SerializeField] GameObject Image;
    // Start is called before the first frame update
    void Start()
    {
        pistol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pistol.SetActive(true);
            Destroy(Player1);
            MainPlayer.SetActive(true);
            Image.SetActive(true);

        }
    }

     
        
    
}
