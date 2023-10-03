using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  public ScoreLogic scoreLogic;
  int health = 3;
  int currentHealth;
  // Start is called before the first frame update
  void Start()
  {
    currentHealth = health;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void TakeDamage(int damage)
  {
    currentHealth -= damage;
    if (currentHealth <= 0)
    {
      Die();
    }
  }

  void Die()
  {
    scoreLogic?.AddScore(1);
    Destroy(gameObject);
  }
}
