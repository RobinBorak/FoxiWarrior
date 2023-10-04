using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  public ScoreLogic scoreLogic;
  int health = 3;
  int currentHealth;

  float speed = 2.0f;
  Transform target;
  Rigidbody2D rb;
  Vector2 moveDirection;

  // Start is called before the first frame update
  void Start()
  {
    currentHealth = health;
    target = GameObject.FindWithTag("Player").transform;
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {

    if(target != null)
    {
      Vector2 direction = target.position - transform.position;

      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      rb.rotation = angle - 180f;
      direction.Normalize();
      moveDirection = direction;
    }

  }

  void FixedUpdate()
  {
    //Stop moving when close to player
    if (Vector2.Distance(transform.position, target.position) < 1.5f)
    {
      return;
    }
    MoveEnemy(moveDirection);
  }

  void MoveEnemy(Vector2 direction)
  {
    rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
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

  void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log("Enemy collided with " + collision.gameObject.tag);
    if (collision.gameObject.tag == "Player")
    {
      collision.gameObject.GetComponent<Player>().TakeDamage(1);
    }
  }
}
