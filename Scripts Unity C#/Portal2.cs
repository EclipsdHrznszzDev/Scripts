using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(2);
            //transform.position = new Vector3(651.114258f, 638.900024f, 597);
            
        }
    }
}
