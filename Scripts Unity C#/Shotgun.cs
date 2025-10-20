using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{ 
    void Start()
    {
        damage = 5;
        ammoMax = 3;
        ammoAll = 10;
        ammoCurrent = 3;
        auto = false;
        cooldown = 1;
        speed = 100;
    }


protected override void OnShoot()
{
    for (int i = 0; i < 1; i++)
    {
        GameObject buf = Instantiate(bullet);
        buf.transform.position = rifleStart.transform.position;
        float x = Random.Range(-10, 10);
        float y = Random.Range(-10, 10);
        buf.transform.rotation = transform.rotation;
        buf.GetComponent<Bullet>().setDirection(transform.forward + new Vector3(x / 500, y / 500, 0));
        gun.Play("Shotgun");
        rifleFire.Play();
        }
}

}