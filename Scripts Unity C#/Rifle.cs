using UnityEngine;
public class Rifle : Gun
{
    void Start()
    {
        damage = 10;
        ammoMax = 25;
        ammoAll = 100;
        ammoCurrent = 25;
        speed = 100;
        auto = true;
        cooldown = 0.3f;
    }
    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bullet);
        buf.transform.position = rifleStart.transform.position;
        buf.transform.rotation = transform.rotation;
        buf.GetComponent<Bullet>().setDirection(transform.forward);
        rifleFire.Play();
        gun.Play("Rifle");
    }
}

