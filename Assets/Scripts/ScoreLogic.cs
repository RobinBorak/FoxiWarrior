using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLogic : MonoBehaviour
{

  public int score = 0;
  public TextMeshProUGUI scoreText;
  int highscore = 0;


  // Start is called before the first frame update
  void Start()
  {

    highscore = PlayerPrefs.GetInt("Highscore", 0);

  }

  public void AddScore(int points)
  {
    score += points;
    scoreText.text = score.ToString();

    if (score > highscore)
    {
      PlayerPrefs.SetInt("Highscore", score);
      PlayerPrefs.SetInt("NewHighscore", 1);
      PlayerPrefs.Save();
    }
  }

}
