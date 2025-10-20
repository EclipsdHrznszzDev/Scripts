using UnityEngine;

public class Playerlookbody : MonoBehaviour
{
    float mouseSense = 10;
    float xAxisClamp = 0;

    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {

        float rotateX = Input.GetAxis("Mouse X") * mouseSense;
        float rotateY = Input.GetAxis("Mouse Y") * mouseSense;

        Vector3 rotPlayer = transform.rotation.eulerAngles;

      
        rotPlayer.z = 0;
        rotPlayer.y += rotateX;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
        }

        transform.rotation = Quaternion.Euler(rotPlayer);
    }
}