using UnityEngine;

public class Dron : Enemy
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject rifleStart;

    float timer = 0;
    float cooldown = 1;

    float area = 30;
    public override void Move()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 80) //100 - радиус обнаружения
        {
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * 5);
        }
    }
    public override void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < area)
        {
            transform.LookAt(player.transform);

            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                timer = 0;
                GameObject buf = Instantiate(bullet);
                buf.transform.position = rifleStart.transform.position;
                buf.transform.rotation = transform.rotation;
                buf.GetComponent<Bullet>().setDirection(transform.forward);
            }
        }
    }
}

