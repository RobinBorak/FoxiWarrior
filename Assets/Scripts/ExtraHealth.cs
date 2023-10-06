using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHealth : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
  }
  // If Player collides with ExtraHealth, destroy ExtraHealth and add 1 to Player's health
  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      Destroy(gameObject);
      collision.gameObject.GetComponent<Player>().AddHealth(1);
    }
  }
}
