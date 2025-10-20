using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventCube : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion; // Делаем ссылку на эффект частиц (взрыв пули при попадании в щит)


    public void ExplosionSmall()
    {
        ParticleSystem buf = Instantiate(explosion); // Инстанцируем систему частиц (создаем клон)
        buf.transform.position = transform.position; // Приравниваем координату "взрыва" координате попавшей в щит пули
        buf.transform.rotation = transform.rotation; // чтобы взрыв был в нушном месте (то же самое с вращением)
        buf.GetComponent<ParticleSystem>().Play(); // Запускаем проигрывание расположенного в нужном месте взрыва (искры)
        Destroy(buf.gameObject, 2f);  // Уничтожаем систему частиц после ее отработки (через 2 сеунды)
    }
}
