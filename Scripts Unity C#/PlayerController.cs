using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public enum Weapon { Pistol, Rifle, Sniper }
    Weapon weapon;
   
    int Level = 0;

    [SerializeField] Text HpText;
    int health;
    public int GetHealth()
    {
        return health;
    }
    bool pause = false;
    [SerializeField] GameObject PauseUI;
    [SerializeField] GameObject Aim;
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject rifle;
    [SerializeField] GameObject Sniper;
    [SerializeField] GameObject MyCamera;
    Vector3 cameraPos;
    [SerializeField] GameObject pistolUI;
    [SerializeField] GameObject rifleUI;
    [SerializeField] GameObject sniperUI;
    [SerializeField] Image HPbar;
    [SerializeField] Animator reload;


    [SerializeField] GameObject forceShield; // Ссылка на щит (будем этот обект включать и выключать)
    bool shieldOn = false; // Переменная для отслеживания - а включен ли щит
    float shieldTimer = 0; // таймер для расчета времени на активацию щита
    float shieldCooldown = 10; // кулдаун на повторную активацию щита (можем еще раз включить щит только через 10 секунд)
    float shieldDuration = 10; // длительность работы щита (5 секунд работает и уходит на 10-секундную перезарядку)

    int chooseweapon = 0;

    [SerializeField] GameObject gameOver;

    [SerializeField] MainMenu canvas;

    public void ChangeHealth(int count)
    {
        health = health + count;
        HpText.text = health.ToString();
        float fill = health / 100f;       // приводим значение нашего ХП к значению между 0 и 1 (0.33 = 33% хп и т.п.)
        HPbar.fillAmount = fill;          // заполняем линию нашего ХП на соответствующий процент
        if (health <= 0)
        {
            gameOver.SetActive(true);
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }


    private void Awake()
    {
        if (PlayerPrefs.HasKey("health"))
        {
            ChangeHealth(PlayerPrefs.GetInt("health"));
            float positionX = PlayerPrefs.GetFloat("playerX");
            float positionY = PlayerPrefs.GetFloat("playerY");
            float positionZ = PlayerPrefs.GetFloat("playerZ");
            transform.position = new Vector3(positionX, positionY, positionZ);

        }
        else
        {
            ChangeHealth(100);
        }
    }
    void Start()
    {
        Levelup();

    }
    public void ChooseWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        switch (weapon)
        {
            
            case Weapon.Pistol:
                pistol.SetActive(true);
                rifle.SetActive(false);
                Sniper.SetActive(false); 
                pistolUI.transform.localScale = new Vector3(1, 1, 1);
                rifleUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                sniperUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                chooseweapon = 1;
                break;
            case Weapon.Rifle:
                pistol.SetActive(false);
                rifle.SetActive(true);
                Sniper.SetActive(false);
                pistolUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                rifleUI.transform.localScale = new Vector3(1, 1, 1);
                sniperUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                chooseweapon = 2;
                break;
            case Weapon.Sniper:
                pistol.SetActive(false);
                rifle.SetActive(false);
                Sniper.SetActive(true);
                pistolUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                rifleUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                sniperUI.transform.localScale = new Vector3(1, 1, 1);
                chooseweapon = 3;
                break;

            default:
                print("Такого оружия у вас нет");
                break;
        }

        FindObjectOfType<Gun>().AmmoTextUpdate();
    }

    public void Levelup()
    {
        Level += 1;
        switch (Level)
        {
            case 1:
                ChooseWeapon(Weapon.Pistol);
                break;
            case 2:
                ChooseWeapon(Weapon.Rifle);
                break;
            case 3:
                ChooseWeapon(Weapon.Sniper);
                break;
            default:
                print("Для этого уровня не подготовлено оружие");
                break;

                //сменить оружие в зависимости от уровня
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cameraPos = new Vector3(MyCamera.transform.localPosition.x, MyCamera.transform.localPosition.y, MyCamera.transform.localPosition.z);
            MyCamera.GetComponent<Camera>().fieldOfView -= 50;
            MyCamera.transform.position = FindObjectOfType<Gun>().GetRifleStart().position;
            Aim.SetActive(true);
            
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            MyCamera.GetComponent<Camera>().fieldOfView += 50;
            MyCamera.transform.localPosition = cameraPos;
            Aim.SetActive(false);
        }



        if (Input.GetKey(KeyCode.Alpha1))
        {
            ChooseWeapon(Weapon.Pistol);
        }

        if (Input.GetKey(KeyCode.Alpha2) && Level >= 2)
        {
            ChooseWeapon(Weapon.Rifle);
        }

        if (Input.GetKey(KeyCode.Alpha3) && Level >= 3)
        {
            ChooseWeapon(Weapon.Sniper);
        }





        if (Input.GetMouseButton(0))
        {
            switch (weapon)
            {
                case Weapon.Pistol:
                    pistol.GetComponent<Gun>().Shoot();
                    break;
                case Weapon.Rifle:
                    rifle.GetComponent<Gun>().Shoot();
                    break;
                case Weapon.Sniper:
                    Sniper.GetComponent<Gun>().Shoot();
                    break;

            }
        }

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    reload.Play("Reload");
        //    GetComponent<Animator>().SetTrigger("reload");

        //}

        shieldTimer += Time.deltaTime; // таймер для нашего щита
        if (Input.GetKeyDown(KeyCode.F) && !shieldOn)  // если мы нажали на кнопку активации щита (и у нас щит не был уже включен)
        {                                           // тогда
            if (shieldTimer > shieldCooldown) // если у нас "зарядился щит" (прошло 10 секунд с момента последней деактивации щита)
            {
                shieldTimer = 0;            // обнуляем таймер
                shieldOn = true;            // выставляем "флаг" "щит включен"
                forceShield.SetActive(true);// активируем непосредственно объект щита
            }
        }
        if (shieldOn && shieldTimer > shieldDuration)  // а если у нас щит сейчас включен И время работы счита прошло (5 секунд)
        {
            forceShield.SetActive(false);  // тогда щит отключаем
            shieldOn = false;              // выставляем флаг деактивации щита
            shieldTimer = 0;               // и обнуляем таймер, чтобы начал отсчитываться кулдаун на повторную активацию щита
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == true)
            {
                pause = false;
                GetComponent<PlayerLook>().enabled = true;
                GetComponent<PlayerMove>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                PauseUI.SetActive(false);
            }
            else
            {
                pause = true;
                GetComponent<PlayerLook>().enabled = false;
                GetComponent<PlayerMove>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                PauseUI.SetActive(true);
            }
        }

    }



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Health")
        {
            Destroy(collider.gameObject);
            ChangeHealth(50);
        }

    }


    
}
