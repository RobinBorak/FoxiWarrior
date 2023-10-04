using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
  public GameObject enemyPrefab;
  float timeSinceLastSpawned = 7f;
  int enemiesSpawned = 0;
  int spawnRate = 10;
  // Start is called before the first frame update
  void Start()
  {
    // Spawn new enemy every x seconds
    //InvokeRepeating("SpawnEnemy", 0.0f, 1.0f);
    //SpawnEnemy();
  }

  // Update is called once per frame
  void Update()
  {
    if (timeSinceLastSpawned > spawnRate)
    {
      SpawnEnemy();
      timeSinceLastSpawned = 0f;
      enemiesSpawned++;
      if (enemiesSpawned % 2 == 0)
      {
        IncreaseSpawnRate();
      }
    }
    else
    {
      timeSinceLastSpawned += Time.deltaTime;
    }
  }

  void IncreaseSpawnRate()
  {
    spawnRate = this.spawnRate * 9 / 10;
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

    // Set the position of the enemy
    enemy.transform.position = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-5.0f, 5.0f), 0);
  }
}
