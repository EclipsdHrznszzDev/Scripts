using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    Transform player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject.transform;
    }

    private void LateUpdate()
    {
        UpdateCamPos();
    }

    void UpdateCamPos()
    {
        Vector3 newPos = player.position;
        //newPos.y = transform.position.y; 
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90, player.eulerAngles.y, 0);
    }


}
