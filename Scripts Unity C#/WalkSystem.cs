using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSystem : MonoBehaviour
{
    [SerializeField] List<Transform> targets = new List<Transform>();
    int i = 0;
    Vector3 vector = new Vector3(0, 0, 0);
   

    public void MoveTo(Transform target)
    {
        GetComponent<Animator>().SetBool("Walk", true);
        vector.x = target.position.x;
        vector.z = target.position.z;
        vector.y = transform.position.y;
        transform.LookAt(vector);
        GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * 2);
    }
   
    
        


    
    public void Walk()
    {
        if (i < targets.Count)
        {
            if (Vector3.Distance(transform.position, targets[i].position) > 1)
            {
                MoveTo(targets[i]);
            }
            else
            {
                i++;
            }
        }
        else
        {
            i = 0;
        }
    }
}
