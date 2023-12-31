using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  // Public variables
  public ScoreLogic scoreLogic;
  public LayerMask playerLayers;
  public Player player;

  // Enemy attributes
  int health = 3;
  int currentHealth;
  float speed = 2.0f;

  // Attack attributes
  Transform attackPoint;
  float attackRate = 1f;
  float timeSinceLastAttack = 100f;
  Animator animator;
  float attackRange = 1f;

  // Movement attributes
  Rigidbody2D rb;
  Transform target;
  Vector2 moveDirection;
  float moveToPlayerDistance = 1f;




  // Start is called before the first frame update
  void Start()
  {
    currentHealth = health;
    // Find target players boxCollider2D
    target = GameObject.FindWithTag("Player").transform;
    rb = GetComponent<Rigidbody2D>();

    animator = GetComponent<Animator>();
    attackPoint = transform.Find("AttackPoint");
  }

  // Update is called once per frame
  void Update()
  {

    if (target != null)
    {
      Vector2 direction = target.position - transform.position;

      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      rb.rotation = angle - 90f;
      direction.Normalize();
      moveDirection = direction;
    }

  }

  void FixedUpdate()
  {
    //When close to target, do stand still and start Attacking and wait attackRate seconds between attacks
    if (Vector2.Distance(transform.position, target.position) < moveToPlayerDistance)
    {
      // Attack player every attackRate delta seconds
      if (timeSinceLastAttack > attackRate)
      {
        Attack();
        timeSinceLastAttack = 0f;
      }
      else
      {
        timeSinceLastAttack += Time.deltaTime;
      }
    }
    else
    {
      // Stop moving when attacking
      if (timeSinceLastAttack > attackRate*2)
      {
        MoveEnemy(moveDirection);
      }
      else
      {
        timeSinceLastAttack += Time.deltaTime;
      }
    }
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
    scoreLogic.AddScore(1);
    player.AddExp(1);
    Destroy(gameObject);
  }

  void Attack()
  {

    //Play an attack animation
    animator.SetTrigger("Attack");

    // Start attackswinger
    Invoke("Swing", attackRate);
  }

  void Swing()
  {

    Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

    foreach (Collider2D player in hitPlayers)
    {
      player.GetComponent<Player>().TakeDamage(1);
    }

  }

  /*
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Enemy collided with " + collision.gameObject.tag);
      if (collision.gameObject.tag == "Player")
      {
        collision.gameObject.GetComponent<Player>().TakeDamage(1);
      }
    }
    */
}
