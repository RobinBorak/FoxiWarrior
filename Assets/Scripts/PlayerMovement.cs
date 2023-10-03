using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  public JoystickMovement joystickMovement;
  public float speed;
  private Rigidbody2D rb;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }


  void FixedUpdate()
  {
    Vector2 direction = joystickMovement.joystickVector;
    rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
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
