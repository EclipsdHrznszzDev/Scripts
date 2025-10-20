using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    float mouseSense = 1;
    float xAxisClamp = 0;

    // Update is called once per frame

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        
        float rotateX = Input.GetAxis("Mouse X") * mouseSense;
        float rotateY = Input.GetAxis("Mouse Y") * mouseSense;

        xAxisClamp -= rotateX;

        Vector3 rotPlayer = transform.rotation.eulerAngles;

        rotPlayer.x -= rotateY;
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