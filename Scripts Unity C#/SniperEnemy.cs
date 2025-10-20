using UnityEngine;

public class SniperEnemy : Enemy
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform rifleStart;
    [SerializeField] GameObject delete;

    float area = 70;
    float timer = 0;
    float cooldown = 3;

    enum Firing { Wait, Prepare, Shoot };
    Firing fire = Firing.Wait;

    float rotateTimer = 0;
    float rotateCooldown = 3;

    public override void DeleteGun()
    {
        delete.SetActive(false);
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    public override void Move()
    {

        //if (fire == Firing.Wait)
        //{
        //    rotateTimer += Time.deltaTime;
        //    if (rotateTimer > rotateCooldown)
        //    {
        //        rotateTimer = 0;
        //        transform.Rotate(new Vector3(0, 90, 0));
        //    }
        //    GetComponent<Animator>().SetBool("Walk", true);
        //    GetComponent<CharacterController>().Move(transform.forward * 1 * Time.deltaTime);
        //}

    }

   
    public override void Attack()
    {

        switch (fire)
        {
            case Firing.Wait:
                if (Vector3.Distance(transform.position, player.transform.position) <= area)
                {
                    GetComponent<Animator>().SetBool("Walk", false);
                    if (fire == Firing.Wait)
                    {
                        rotateTimer += Time.deltaTime;
                        if (rotateTimer > rotateCooldown)
                        {
                            rotateTimer = 0;
                            transform.Rotate(new Vector3(0, 90, 0));
                        }

                        GetComponent<CharacterController>().Move(transform.forward * 1 * Time.deltaTime);
                    }
                    fire = Firing.Prepare;
                }
                break;
            case Firing.Prepare:
                timer += Time.deltaTime;
                transform.LookAt(player.transform);
                if (timer > cooldown)
                {
                    fire = Firing.Shoot;
                }
                break;
            case Firing.Shoot:
                timer = 0;
                GameObject buf = Instantiate(bullet);
                buf.transform.position = rifleStart.transform.position;
                buf.transform.rotation = transform.rotation;
                buf.GetComponent<Bullet>().setDirection(transform.forward);
                buf.GetComponent<Bullet>().MakeSniper();
                fire = Firing.Wait;
                break;
        }
    }
}