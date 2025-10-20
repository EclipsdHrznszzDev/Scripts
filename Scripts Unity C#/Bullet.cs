using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 150;
    Vector3 direction;
    int health;

    bool mage = false;
    bool Forceshield = false;
    int damage = 20;


    public void MakeSniper()
    {
        speed = 150;
        damage = 50;
    }

    public void MakeMage()
    {
        damage = 5;
        mage = true;
        speed = 15;
    }
    public void forceshield()
    {
        Forceshield = true;

    }
    public void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        Destroy(gameObject, 40f);
    }
    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        speed += 1f;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().ChangeHealth(-damage);
  
            Destroy(gameObject);
            
        }

      
        
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().ChangeHealth(-damage);
            if (mage)
            {
                FindObjectOfType<PlayerMove>().MageHit();
            }
            Destroy(gameObject);
            if (Forceshield)
            {
                FindObjectOfType<PlayerController>().ChangeHealth(+0);
            }
        }
        Destroy(gameObject);
    }
}