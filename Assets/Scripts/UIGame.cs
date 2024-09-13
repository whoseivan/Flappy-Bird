using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class UIGame : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    private void Start()
    {
        highscoreText.text = "Highscore: " + 0.ToString();
        panel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        FlappyBird.died += UIEnable;
        TubesSpawn.collect += CoinCollect;
    }

    void UIEnable()
    {
        scoreText.gameObject.SetActive(false);
        panel.SetActive(true);
    }

    void CoinCollect(int coins)
    {
        scoreText.text = coins.ToString();
        highscoreText.text = "Highscore: " + coins.ToString();
    }
}
