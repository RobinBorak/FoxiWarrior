using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

  public Animator animator;
  public Transform attackPoint;
  float attackRange = 1f;
  public LayerMask enemyLayers;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Attack();
    }

  }

  public void Attack()
  {
    //Play an attack animation
    animator.SetTrigger("Attack");

    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

    foreach (Collider2D enemy in hitEnemies)
    {
      enemy.GetComponent<Enemy>().TakeDamage(1);
    }

  }
}
