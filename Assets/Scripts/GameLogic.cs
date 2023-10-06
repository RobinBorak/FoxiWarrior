using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
  public GameObject enemyPrefab;
  public GameObject heartPrefab;
  float timeSinceLastEnemySpawned = 7f;
  float timeSinceLastHeartSpawned = 0f;
  int enemiesSpawned = 0;
  int enemySpawnRate = 10;
  float nextHeartSpawn = 0f;
  // Start is called before the first frame update
  void Start()
  {
    nextHeartSpawn = Random.Range(30f, 80f);
    Physics2D.IgnoreLayerCollision(8, 8);
    Physics2D.IgnoreLayerCollision(7, 8);
  }

  // Update is called once per frame
  void Update()
  {
    InitSpawnEnemy();
    InitSpawnHeart();
  }


  void InitSpawnEnemy()
  {
    if (timeSinceLastEnemySpawned > enemySpawnRate)
    {
      SpawnEnemy();
      timeSinceLastEnemySpawned = 0f;
      enemiesSpawned++;
      if (enemiesSpawned % 2 == 0)
      {
        IncreaseSpawnRate();
      }
    }
    else
    {
      timeSinceLastEnemySpawned += Time.deltaTime;
    }
  }
  void IncreaseSpawnRate()
  {
    enemySpawnRate = this.enemySpawnRate * 9 / 10;
  }

  void SpawnEnemy()
  {
    // Get the enemy prefab
    //GameObject enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
    // Instantiate the enemy
    GameObject enemy = Instantiate(enemyPrefab);
    // Get the enemy script component
    Enemy enemyScript = enemy.GetComponent<Enemy>();
    // Set the score logic from tag "ScoreLogic"
    enemyScript.scoreLogic = GameObject.FindWithTag("ScoreLogic").GetComponent<ScoreLogic>();

    // Set the position of the enemy on the edges of the screen
    float x = Random.Range(0, 2) == 0 ? -8f : 8f;
    float y = Random.Range(-4f, 4f);
    enemy.transform.position = new Vector3(x, y, 0);

  }

  void InitSpawnHeart()
  {
    if (timeSinceLastHeartSpawned > nextHeartSpawn)
    {
      SpawnHeart();
      //Is extra lucky spawn 2 more hearts
      if (Random.Range(0, 100) > 90)
      {
        SpawnHeart();
        SpawnHeart();
      }
      timeSinceLastHeartSpawned = 0f;
      nextHeartSpawn = Random.Range(10f, 80f);
    }
    else
    {
      timeSinceLastHeartSpawned += Time.deltaTime;
    }
  }

  void SpawnHeart()
  {
    GameObject heart = Instantiate(heartPrefab);
    heart.transform.position = new Vector3(Random.Range(-6.0f, 6.0f), Random.Range(-4.0f, 4.0f), 0);
  }
}
