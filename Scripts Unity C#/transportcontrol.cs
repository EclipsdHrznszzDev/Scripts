using UnityEngine;
using UnityEngine.UI;

public class transportcontrol : MonoBehaviour
{
    Vector3 startPosition;
    void start()
    {
        startPosition = transform.position;

    }

    [SerializeField] float speed = 20f;

    [SerializeField] Text timeText;

    private float rotation = 0.0f;
    private float acceleration = 0.0f;
    public float RotationSpeed = 90.0f;
    public float MovementSpeed = 2.0f;
    public float MaxSpeed = 0.2f;

    private bool controllable = true;


    Vector3 direction = new Vector3();

    private new Rigidbody rigidbody;
    public void Awake()
    {


        rigidbody = GetComponent<Rigidbody>();

    }


        // Update is called once per frame
        void Update()
    {
        if (!controllable)
        {
            return;
        }

        rotation = Input.GetAxis("Horizontal");
        acceleration = Input.GetAxis("Vertical");


    }

    public void FixedUpdate()
    {


        if (!controllable)
        {
            return;
        }

        Quaternion rot = rigidbody.rotation * Quaternion.Euler(0, rotation * RotationSpeed * Time.fixedDeltaTime, 0);
        rigidbody.MoveRotation(rot);

        Vector3 force = (rot * Vector3.forward) * acceleration * 1000.0f * MovementSpeed * Time.fixedDeltaTime;
        rigidbody.AddForce(force);

        if (rigidbody.velocity.magnitude > (MaxSpeed * 1000.0f))
        {
            rigidbody.velocity = rigidbody.velocity.normalized * MaxSpeed * 1000.0f;
        }


       
    }
    
   
    
}




