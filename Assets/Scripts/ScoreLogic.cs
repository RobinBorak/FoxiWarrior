using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLogic : MonoBehaviour
{

  public int score = 0;
  public TextMeshProUGUI scoreText;


  // Start is called before the first frame update
  void Start()
  {

  }

  public void AddScore(int points)
  {
    score += points;
    scoreText.text = score.ToString();
  }

}
