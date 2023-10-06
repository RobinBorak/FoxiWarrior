using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelUp : MonoBehaviour
{

  //After 5 seconds, deactive the LevelUp 
  IEnumerator DisableAfterTime()
  {
    yield return new WaitForSeconds(5);
    gameObject.SetActive(false);
  }

  // Start is called before the first frame update
  void Start()
  {
    //Listen to on level up
    Player.onLevelUp += OnLevelUp;
    gameObject.SetActive(false);
  }

  void OnLevelUp()
  {
    gameObject.SetActive(true);
    StartCoroutine(DisableAfterTime());
  }
}
