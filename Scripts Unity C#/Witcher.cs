using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witcher : Enemy
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void Move()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 30) //100 - радиус обнаружения
        {
            GetComponent<Animator>().SetBool("Walk", true);
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * 10);
        }
    }

}
