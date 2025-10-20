using UnityEngine;

public class Turret : Enemy
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject rifleStart;

    float timer = 0;
    float cooldown = 1;

    float area = 60;
    
    public override void Move()
    {
        //if (Vector3.Distance(transform.position, player.transform.position) < 100) //100 - радиус обнаружения
        //{
            //transform.LookAt(player.transform);
       //     GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * 2);
       // }
    }
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject; //Находим игрока


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

    
  
       

