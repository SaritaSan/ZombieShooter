using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
     public GameObject enemyPrefab;
     public GameObject enemyPrefab2; // Asigna aquí tu prefab de enemigo en el Inspector
    public float spawnRadius = 10f; // Radio donde aparecerán los enemigos
    public float spawnRate = 3f; // Tiempo entre cada spawn
 
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
 
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }
    }
 
    void SpawnEnemy()
    {
        Vector2 spawnPosition = Random.insideUnitCircle * spawnRadius;
        float groundHeight = 0f; // Ajusta esto a la altura correcta del terreno
        Instantiate(enemyPrefab, new Vector3(spawnPosition.x, groundHeight, spawnPosition.y), Quaternion.identity);
        Instantiate(enemyPrefab2, new Vector3(spawnPosition.x, groundHeight, spawnPosition.y), Quaternion.identity);
    }
}
