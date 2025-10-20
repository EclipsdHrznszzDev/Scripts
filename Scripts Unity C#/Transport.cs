using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{

    [SerializeField] GameObject mycamera;
    [SerializeField] GameObject Cameratransport;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject spsh;
    [SerializeField] GameObject Flesh;



    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<transportcontrol>().enabled = true;
            GetComponent<PlayerLook>().enabled = true;
            Cameratransport.transform.position = new Vector3(627.5f, 657, 346.200012f);
            Destroy(mycamera);
            Destroy(Player);
            spsh.SetActive(false);

            Flesh.SetActive(true);



        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
