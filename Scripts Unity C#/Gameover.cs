using UnityEngine;
using UnityEngine.SceneManagement;


public class Gameover : MonoBehaviour
{

    public void Loadgameafterover()
    {

        SceneManager.LoadScene(2);
    }
}