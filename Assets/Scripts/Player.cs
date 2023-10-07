using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  public float speed = 2.5f;
  public TextMeshProUGUI healthText;
  public delegate void OnLevelUp();
  public static event OnLevelUp onLevelUp;

  int health = 10;
  int currentHealth;

  int level = 1;
  int exp = 0;
  int[] expStages = { 0, 5, 10, 15, 20, 30, 40, 50, 60, 70 };

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

  void LevelUp()
  {
    Debug.Log("Level up!");
    level++;
    speed += 0.5f;
    onLevelUp?.Invoke();
  }

  public void AddExp(int expToAdd)
  {
    exp += expToAdd;
    if (level < expStages.Length && exp >= expStages[level])
    {
      LevelUp();
    }
  }

}
