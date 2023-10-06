using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    AddHealth(-1);
    if (currentHealth <= 0)
    {
      Die();
    }
  }

  void Die()
  {
    SceneManager.LoadScene(2);
  }

  public void AddHealth(int healthToAdd)
  {
    currentHealth += healthToAdd;
    healthText.text = currentHealth.ToString();
  }
}
