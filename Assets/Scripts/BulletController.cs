using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 40.0f;
    private float range = 20.0f;
    private PlayerController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = PlayerController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        if(transform.position.z > range || transform.position.z < -range)
        {
            Destroy(gameObject);
        }
        if(transform.position.x > range || transform.position.x < -range)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            print("Enemy is Destroted");
        }
    }
}
