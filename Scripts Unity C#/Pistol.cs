
using UnityEngine;

public class Pistol : Gun
{


    void Start()
    {
        damage = 20;
        ammoMax = 12;
        ammoAll = 30;
        ammoCurrent = 12;
        cooldown = 0.5f;
        speed = 100;
        auto = false;
    }
    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bullet);
        buf.transform.position = rifleStart.transform.position;
        buf.transform.rotation = transform.rotation;
        buf.GetComponent<Bullet>().setDirection(transform.forward);
        rifleFire.Play();
        gun.Play("pistolanimation");
    }
}