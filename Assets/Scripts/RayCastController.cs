using UnityEngine;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private float length = 40.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, length))
            {
                print("ray hitted to: " + hit.collider.name);
                // if (hit.collider.tag == "Enemy")
                // {
                //     Destroy(hit.collider.gameObject);
                // }
            }
            Debug.DrawRay(transform.position, transform.forward * length, Color.red);
        }
    }
}
