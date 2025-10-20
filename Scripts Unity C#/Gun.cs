
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Transform rifleStart;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected GameObject bullet1;
    [SerializeField] protected ParticleSystem rifleFire;
    [SerializeField] protected Animator gun;

    [SerializeField] Text ammoText;// показываем в интерфейсе наши патроны "в обойме" и "всего" (одной строкой = "10 / 100")

    protected int ammoCurrent = 10;     // количество патронов в текущей обойме
    protected int ammoMax = 10;         // максимальное количество патронов в обойме данного типа оружия
    protected int ammoAll = 100;        // всего патронов у нас в запасе
    protected bool auto = false;
    protected int damage = 0;
    protected float cooldown = 0;
    protected float speed = 20;

    private float timer = 0;

    public void AddAmmo(int count)           // функция добавления патронов (чтобы можно было разбросать по карте патроны
    {
        ammoAll += count;                    // и собирать их
    }

    public Transform GetRifleStart()
    {
        return rifleStart;
    }

    protected virtual void OnShoot()
    {

    }


    private void Start()
    {
        timer = cooldown;
        AmmoTextUpdate();    // в старте обновляем интерфейс патронов
    }
    public void AmmoTextUpdate()    // функция обновления интерфейса патронов
    {
        ammoText.text = ammoCurrent + " / " + ammoAll;     // просто прописываем сколько у нас патронов всего и в запасе
    }

    public void Reload()            // функция "попытки вызова" перезарядки
    {
        if (!Input.GetKeyDown(KeyCode.R)) return; //Ничего не делать если не нажали R
        if (ammoCurrent == ammoMax) return; //Ничего не делать если полная обойма
        if (ammoAll == 0) return; //Ничего не делать если нет ничего в запасе
        Invoke("InvokeReload", 1);   // "через 1 секунду" вызовется функция непосредственной перезарядки "ИнвокРелоад"
    }

    private void InvokeReload()  // непосредственная функция перезарядки
    {
        int ammoNeed = ammoMax - ammoCurrent; //Сколько патронов добавить в обойму
        if (ammoAll >= ammoNeed) //Если патронов в запасе больше чем надо
        {
            ammoAll -= ammoNeed;       // вычитаем из запаса патронов необходимое количество патронов до полной обоймы
            ammoCurrent += ammoNeed;   // загружаем обойму под завязку
        }
        else //Если патронов в запасе меньше чем надо
        {
            ammoCurrent += ammoAll;      // выгружаем в обойму все оставшиеся патроны
            ammoAll = 0;                 // все, патроны кончились!
        }
        AmmoTextUpdate();                // обновляем интерфейс патронов при перезарядке
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Reload();
    }
    
    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || auto)
        {
            if (timer > cooldown)
            {
                if (ammoCurrent > 0 && !IsInvoking("InvokeReload"))
                {
                    OnShoot();

                    timer = 0;
                    ammoCurrent = ammoCurrent - 1;    // вычитаем патрон из обоймы при выстреле
                    AmmoTextUpdate();                 // и обновляем интерфейс патронов
                    GetComponent<Animator>().SetTrigger("Shoot");
                }
                else
                {
                    GetComponent<AudioSource>().Play();   // это звук "выстрела" при отсутствующих патр

                }

            }
        }
    }
   
    

    
}