using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    Vector3 startPosition;
    void start()
    {
        startPosition = transform.position;

    }
    [SerializeField] float speed = 9f;

    [SerializeField] float gravity = 1000;

    [SerializeField] CharacterController controller;

    [SerializeField] Text scoreText;

    [SerializeField] Text timeText;

  

    int crystal = 0;

    float time = 0;
    Vector3 direction = new Vector3();

    float speedDebufTimer = 0; // Таймер для отсчета времени замедления
    float speedDebufCooldown = 8; // Длительность замедления
    bool speedDebuf = false; // Переменная для реализации "выхода" из состояния замедления

    public void MageHit()  // Функция, которая вызывается при попадании мага по нашему персонажу
    {
        speed = 2; // Накладываем штраф скорости (по умолчанию у меня скорость = 5, а при штрафе становится 3
        speedDebuf = true; // Включаем флаг штрафа (чтобы отследить это состояние в Апдейте)
        speedDebufTimer = 0; // Запускаем таймер с нуля
    }

    public void ocean()
    {
         gravity = 2;
    }
    public void surface()
    {
        gravity = 17;
    }
    // Update is called once per frame
    void Update()
    {
        if (speedDebuf) // Если наш флаг состояния штрафа скорости true, 
        {
            speedDebufTimer += Time.deltaTime; // то отсчитываем наш таймер (5 секунд)
            if (speedDebufTimer > speedDebufCooldown) // и если 5 секунд прошли,
            {
                speedDebuf = false; // то "выключаем" флаг состояния штрафа скорости и
                speed = 9; // Возвращаем скорость к базовому состоянию
            }

        }

        if (crystal < 30)
        {
            time += Time.deltaTime;
            int newTime = (int)time;

            timeText.text = time.ToString();
            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !speedDebuf)
        {
            speed = 15;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !speedDebuf)
        {
            speed = 9;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            direction = transform.TransformDirection(direction) * speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = 8;
            }
        }

        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

        if (transform.position.y < -20)
        {
            transform.position = startPosition;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            Destroy(other.gameObject);
            crystal += 1;

            scoreText.text = crystal.ToString();
            
        }
    }
    public int GetCrystals()
    {
        return crystal;
    }

    public void deleteCrystalls(int count)
    {
        crystal -= count;
        scoreText.text = crystal.ToString();
    }
}




