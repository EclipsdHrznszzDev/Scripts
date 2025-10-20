using UnityEngine;

public class Sniper : Gun
{



    void Start()
    {
        damage = 50;
        ammoMax = 5;
        ammoAll = 20;
        ammoCurrent = 5;
        cooldown = 2;
        speed = 120;
        auto = false;
    }
    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bullet1);
        buf.transform.position = rifleStart.transform.position;
        buf.transform.rotation = transform.rotation;
        buf.GetComponent<Bullet>().setDirection(transform.forward);
        gun.Play("Snipe");
        rifleFire.Play();
        
    }
}