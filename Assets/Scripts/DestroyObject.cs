using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private GameObject enemy;
    private EnemyController enemyDestroy;


    private void Awake()
    {
        enemyDestroy = EnemyController.em;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = GameObject.Find("EnemyCollider");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
