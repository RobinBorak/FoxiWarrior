using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
  public TextMeshProUGUI healthText;
  int health = 10;
  int currentHealth;

  // Start is called before the first frame update
  void Start()
  {
    currentHealth = health;
    healthText.text = currentHealth.ToString();
  }

  public void TakeDamage(int damage)
  {
    Debug.Log("Player took damage");
    currentHealth -= damage;
    healthText.text = currentHealth.ToString();
    if (currentHealth <= 0)
    {
      Die();
    }
  }

  void Die()
  {
    Debug.Log("Player died");
  }
}
