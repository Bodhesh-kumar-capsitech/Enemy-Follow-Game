using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int startTime = 2;
    [SerializeField] private int delayTime = 3;
     [SerializeField] GameObject PlayerbulletPrefab;
     [SerializeField] GameObject EnemybulletPrefab;

    [SerializeField] Transform player;
    private GameObject enemy;

    void Start()
    {
         PlayerbulletPrefab.transform.position = player.position;
        StartCoroutine(PlayerBulletSpawn());
        StartCoroutine(EnemySpawnTime());
    }

    private IEnumerator EnemySpawnTime()
    {
        yield return new WaitForSeconds(startTime);

        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(delayTime);
        }
    }
    
    //Code for Player bullet spawn
     private IEnumerator PlayerBulletSpawn()
    {
        while(true)
        {
            Instantiate(PlayerbulletPrefab,player.position,player.transform.rotation);
            yield return new WaitForSeconds(0.2f);
        }
    }

    //Code for Enemy bullet spawn
     private IEnumerator EnemyBulletSpawn()
    {
        while(true)
        {
            Instantiate(EnemybulletPrefab,enemy.transform.position,enemy.transform.rotation);
            yield return new WaitForSeconds(1.0f);
        }
    }

    //Code for enemy spawn
    private void SpawnEnemy()
    {
        float spawnPosX = Random.Range(-16, 16);
        float spawnPosZ = Random.Range(0, 16);

        Vector3 pos = new Vector3(spawnPosX, transform.position.y, spawnPosZ);

        enemy = ObjectPool.Instance.GetObject();
        enemy.transform.position = pos;

         Vector3 direction = player.position - pos;
        direction.y = 0; 

        enemy.transform.rotation = Quaternion.LookRotation(direction);
        StartCoroutine(EnemyBulletSpawn());

    }
}
