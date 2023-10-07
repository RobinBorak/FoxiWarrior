using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{

  public static bool isPaused = false;
  public GameObject pauseMenuUI;
  public TextMeshProUGUI pauseIconText;

  void Start()
  {
  }

  public void TogglePause()
  {
    if (isPaused)
    {
      Resume();
    }
    else
    {
      PauseGame();
    }
  }

  void Resume()
  {
    pauseMenuUI.SetActive(false);
    isPaused = false;
    pauseIconText.text = "II";
    Time.timeScale = 1f;
  }

  void PauseGame()
  {
    pauseMenuUI.SetActive(true);
    isPaused = true;
    pauseIconText.text = "Resume";
    Time.timeScale = 0f;
  }

}
