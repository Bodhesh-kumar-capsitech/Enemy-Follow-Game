using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float turnSpeed = 150.0f;
    [SerializeField] private float rangeX = 18.0f;
    [SerializeField] private float rangeZ = 18.0f;
    public int hitcount = 0;

     private float horizontal;
    private float vertical;
    private Rigidbody rb;
    public static PlayerController instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX |RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        //Rotate left & right
        float rotation = horizontal * turnSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotation, 0f));

        float clampedX = Mathf.Clamp(transform.position.x, -rangeX, rangeX);
        float clampedZ = Mathf.Clamp(transform.position.z, -rangeZ, rangeZ);
        transform.position = new Vector3(clampedX,transform.position.y,clampedZ);

        print("hit count is: " + hitcount);

        if( hitcount > 10 )
        {
            Destroy(gameObject);
            hitcount = 0;
            Time.timeScale = 0;
        }

    }

}
