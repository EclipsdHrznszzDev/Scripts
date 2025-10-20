using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(4);
        }
    }


}
