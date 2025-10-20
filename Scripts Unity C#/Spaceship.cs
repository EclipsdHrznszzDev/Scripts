using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{

    //[SerializeField] protected Animator Kat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ship")
        {
            SceneManager.LoadScene(5);
            //FindObjectOfType<Katscene>().enabled = true;
            //Kat.Play("Katscene");
        }
    }
}
