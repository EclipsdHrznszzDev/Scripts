using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _crystalObject;
    [SerializeField] private float _radius;
    [SerializeField] private float _cooldown;

    private float time = 0;



    private void Start()
    {

    }
    private void Update()
    {
        time += Time.deltaTime;

        if (time > _cooldown)
        {
            GameObject crystal = Instantiate(_crystalObject);

            float x = Random.Range(-_radius, _radius);
            float z = Random.Range(-_radius, _radius);

            crystal.transform.position = transform.position + new Vector3(x, 0, z);

                time = 0;

        }


    }
}



