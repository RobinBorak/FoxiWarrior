using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
  public GameObject enemyPrefab;
  // Start is called before the first frame update
  void Start()
  {
    // Spawn new enemy every 2 seconds
    InvokeRepeating("SpawnEnemy", 0.0f, 2.0f);
  }

  // Update is called once per frame
  void Update()
  {
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
