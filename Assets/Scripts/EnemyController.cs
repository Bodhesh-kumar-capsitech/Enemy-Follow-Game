using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float rangeX = 18.0f;
    [SerializeField] private float rangeZ = 16.0f;
    [SerializeField] private float speed = 2.0f;

    private GameObject playerPrefab;
    private Rigidbody rb;
    public static EnemyController em;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        em = this;
        playerPrefab = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerPrefab.transform.position;

        
        transform.position = Vector3.MoveTowards(transform.position, playerPrefab.transform.position, speed * Time.deltaTime);

        float x = Mathf.Clamp(transform.position.x,-rangeX,rangeX);
        float z = Mathf.Clamp(transform.position.z,-rangeZ,rangeZ);
        transform.position = new Vector3(x, transform.position.y, z);

        
    }

    public void Die()
    {
        ObjectPool.Instance.ReturnObject(this.gameObject);
    }

}
