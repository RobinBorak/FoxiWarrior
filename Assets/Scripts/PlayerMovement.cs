using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  public JoystickMovement joystickMovement;
  public float speed;
  private Rigidbody2D rb;
  private Animator animator;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }


  void FixedUpdate()
  {
    Vector2 direction = joystickMovement.joystickVector;
    rb.velocity = new Vector2(direction.x * speed, direction.y * speed);

    // Rotate the player to face the direction of movement
    if (direction != Vector2.zero)
    {
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      rb.rotation = angle - 90f;

      // Play the walking animation
      animator.SetBool("isWalking", true);
    } else {
      // Stop the walking animation
      animator.SetBool("isWalking", false);
    }

  }

  /*
    // Update is called once per frame
    void Update()
    {
      change = Vector3.zero;
      change.x = Input.GetAxisRaw("Horizontal");
      change.y = Input.GetAxisRaw("Vertical");
      if (change != Vector3.zero)
      {
        MoveCharacter();
      }
    }

    void MoveCharacter()
    {
      rb.MovePosition(
        transform.position + (change * speed * Time.deltaTime)
      );
    }
    */
}
