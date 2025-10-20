using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceShield : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion; // Делаем ссылку на эффект частиц (взрыв пули при попадании в щит)

    private void OnTriggerEnter(Collider other)  // При пересечении какого-то объекта со щитом:
    {
        if (other.tag == "Bullet")  // Если в наш щит влетела пуля (довавь тэг Bullet префабу твоих пуль, которые ты используешь)
        {
            ParticleSystem buf = Instantiate(explosion); // Инстанцируем систему частиц (создаем клон)
            buf.transform.position = other.transform.position; // Приравниваем координату "взрыва" координате попавшей в щит пули
            buf.transform.rotation = other.transform.rotation; // чтобы взрыв был в нушном месте (то же самое с вращением)
            buf.GetComponent<ParticleSystem>().Play(); // Запускаем проигрывание расположенного в нужном месте взрыва (искры)
            Destroy(buf.gameObject, 2f);  // Уничтожаем систему частиц после ее отработки (через 2 сеунды)
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
            GetComponent<Bullet>().forceshield();
        }
    }



    public void Explosion()
    {
        ParticleSystem buf = Instantiate(explosion); // Инстанцируем систему частиц (создаем клон)
        buf.transform.position = transform.position; // Приравниваем координату "взрыва" координате попавшей в щит пули
        buf.transform.rotation = transform.rotation; // чтобы взрыв был в нушном месте (то же самое с вращением)
        buf.GetComponent<ParticleSystem>().Play(); // Запускаем проигрывание расположенного в нужном месте взрыва (искры)
        Destroy(buf.gameObject, 2f);  // Уничтожаем систему частиц после ее отработки (через 2 сеунды)
    }

    public void CallForSmallExplosion()
    {
        GetComponentInChildren<AnimEventCube>().ExplosionSmall();
    }
}
