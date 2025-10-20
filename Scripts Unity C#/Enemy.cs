using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    protected int damage;
    //урон который враг наносит
    protected int health = 100; //здоровье врага
    [SerializeField] protected GameObject player; //Информация о игроке
    bool dead = false; //Мертвый ли враг

    Vector3 HPbarBasePos = new Vector3(7, 1, 1); // базовый размер полоски ХП врага

    protected Text EnemyHealth;                    // это цифра ХП врага

    protected Image enemysHPbar;                   // а это картинка с линией ХП врага (HP bar)
    


    public void ChangeHealth(int count)
    {
        health = health + count;          // враг получает урон (меняем значение его переменной хелс)
        GameObject.Find("EnemyesHP").transform.localScale = HPbarBasePos; // делаем "видимой" полоску ХП врага


        EnemyHealth = GameObject.Find("Enemy Health").GetComponent<Text>();  // находим элемент UI Text для цифры ХП врага
        EnemyHealth.text = health.ToString();                                // добавляем в это UI поле текущее ХП врага


        enemysHPbar = GameObject.Find("EnHPbar").GetComponent<Image>();      // находим объект линии ХП врага
        float fill = health / 100f;                                      // находим сколько процентов (~0.33) составляет хп
        enemysHPbar.fillAmount = fill;                                   // заполняем нашу линию ХП соответствующим значением
        if (health <= 0)
        {
            print("dead");
            OnDeath();

        }
        if (IsInvoking("InvokeOffHPbar"))     // если у нас запущен отсроченный запуск сокрытия линии ХП врага
        {
            CancelInvoke("InvokeOffHPbar");   // то отключаем его
            Invoke("InvokeOffHPbar", 4);      // и перезапускаем заново (чтобы 4 секунды задержки начали считаться с начала)
        }
        else                                  // а если процесс отсроченного запуска еще не запускался, 
        {
            Invoke("InvokeOffHPbar", 4);      // то просто запускаем его
        }
    }

    public void InvokeOffHPbar()                       // сама функция сокрытия линии ХП врага 
    {
        GameObject.Find("EnemyesHP").transform.localScale = Vector3.zero; // просто делает размер этого объекта равным 0
    }                                                                     // да, такой хитрый аналог невидимости :)

    public virtual void DeleteGun()
    {

    }
    public virtual void Move() //Враг может как-то двигаться
    {

    }

  
    public virtual void Attack() //Враг может как-то атаковать
    {

    }
    public void OnDeath() //Умирают враги одинаково
    {
        dead = true;
        GetComponent<Animator>().SetTrigger("dead"); //изменили параметр анимации
        GetComponent<CharacterController>().enabled = false; //отключили коллайдер
        DeleteGun();

        FindObjectOfType<PlayerController>().gameObject.GetComponent<PlayerController>().Levelup();
    }
    public bool isDead()
    {
        return dead;
    }

   

    private void Update() //Если враг не мертв, он двигается и атакует
    {
        if (!dead)
        {
            Move();
            Attack();
        }
    }
}
