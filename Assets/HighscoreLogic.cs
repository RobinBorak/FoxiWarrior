using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreLogic : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI newHighscoreText;
    int highscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = highscore.ToString();

        if(PlayerPrefs.GetInt("NewHighscore", 0) == 1)
        {
            newHighscoreText.gameObject.SetActive(true);
        }
        else
        {
            newHighscoreText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
