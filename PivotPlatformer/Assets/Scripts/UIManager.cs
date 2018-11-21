using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour {
    public Player player;

    public float timer = 60f;
    public  TextMeshProUGUI countdownText;
    public int score;
    public TextMeshProUGUI scoreText;

    private string timerFormat;


	// Use this for initialization
	void Start ()
    {
        timerFormat = countdownText.text;
	}
	
	// Update is called once per frame
	void Update ()
    {
        countdownText.text = string.Format(timerFormat, Mathf.FloorToInt(timer / 60F), Mathf.FloorToInt(timer % 60F).ToString().PadLeft(2, '0'));
        scoreText.text = "Score: " + score;

        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            timer = 0F;
            player.Die();
        }
	}
}
